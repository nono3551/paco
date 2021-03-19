using Paco.SystemManagement.FreeBsd.Commands;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using Paco.Entities.Models;
using Paco.Entities.Models.Updating;
using Paco.SystemManagement.Ssh;

namespace Paco.SystemManagement.FreeBsd
{
    public class FreeBsdManager : ISystemManager
    {
        public ManagedSystem System { get; }

        public FreeBsdManager(ManagedSystem system)
        {
            System = system;
        }

        public Dictionary<string, string> GetSystemInformation()
        {
            using var client = SshManager.CreateSshClient(System);

            var packagesActions = ActionsProvider.GetPackagesActions(client).ToList();

            System.PackageActions = packagesActions.Count();
            
            return new Dictionary<string, string>
            {
                { "Hostname", new Hostname().GetHostname(client) },
                { "Logged users", Uptime.CurrentLoggedUsers(client) },
                { "Karnel\nUserland\nRunning", $"{SystemVersion.GetKarnel(client)}{SystemVersion.GetUserland(client)}{SystemVersion.GetRunning(client)}" },
                { "Vulnerable packages", Audit.GetVulnerablePackages(client) },
                { $"Packages actions ({System.PackageActions})", string.Join("\n", packagesActions)},
            };
        }

        public KeyValuePair<bool, string> PackagesActionsNeedsInteraction()
        {
            using var client = SshManager.CreateSshClient(System);
            return Audit.PackagesActionsNeedsInteraction(client);
        }

        public void PreparePackagesActions(IEnumerable<object> actions)
        {
            using var client = SshManager.CreateSshClient(System);
            PrepareActions.PreparePackageActions(client, actions);
        }

        public void ExecuteScheduledAction(ScheduledAction scheduledAction)
        {
            using var client = SshManager.CreateSshClient(System);
            if (scheduledAction.ScheduledActionType == ScheduledActionType.Packages)
            {
                Packages.UpdatePackages(client, scheduledAction);
            }
            
        }

        public string GetScheduledActionDetails(ScheduledAction scheduledAction)
        {
            using var client = SshManager.CreateSshClient(System);
            if (scheduledAction.ScheduledActionType == ScheduledActionType.Packages)
            {
                return Packages.GetScheduledActionDetail(client, scheduledAction);
            }
            else
            {
                return "Not yet supported";
            }
        }

        public IEnumerable<object> GetPackagesActions(bool shouldRefresh = false)
        {
            using var client = SshManager.CreateSshClient(System);
            var actions = ActionsProvider.GetPackagesActions(client, shouldRefresh);
            return actions;
        }

        public bool IsSystemUpdateAvailable()
        {
            return new CheckVersion().IsNewVersionVersionAvailable(SshManager.CreateSshClient(System));
        }
    }
}