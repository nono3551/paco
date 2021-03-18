using Paco.SystemManagement.FreeBsd.Commands;
using System.Collections.Generic;
using Paco.Entities.Models;
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

            return new Dictionary<string, string>
            {
                { "Hostname", new Hostname().GetHostname(client) },
                { "Logged users", Uptime.CurrentLoggedUsers(client) },
                { "Karnel version", new KarnelVersion().GetKarnel(client) },
                { "Userland version", new KarnelVersion().GetUserland(client) },
                { "Running Karnel version", new KarnelVersion().GetRunning(client) },
                { "Vulnerable packages", Audit.GetVulnerablePackages(client) },
                { "Packages updates", string.Join("\n", ActionsProvider.GetPackagesActions(client))},
            };
        }

        public KeyValuePair<bool, string> UpdateNeedsInteraction()
        {
            using var client = SshManager.CreateSshClient(System);
            return Audit.UpdateNeedsInteraction(client);
        }

        public void PreparePackagesActions(IEnumerable<object> actions)
        {
            using var client = SshManager.CreateSshClient(System);
            PrepareActions.PreparePackageActions(client, actions);
        }

        public void UpdatePackages()
        {
            using var client = SshManager.CreateSshClient(System);
            Update.UpdatePackages(client);
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