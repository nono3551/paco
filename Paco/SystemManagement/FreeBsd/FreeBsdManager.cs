using System;
using Paco.SystemManagement.FreeBsd.Commands;
using System.Collections.Generic;
using System.Linq;
using Paco.Entities;
using Paco.Entities.Models;
using Paco.Entities.Models.Updating;
using Paco.SystemManagement.Ssh;

namespace Paco.SystemManagement.FreeBsd
{
    public class FreeBsdManager : ISystemManager
    {
        private ManagedSystem System { get; }

        public FreeBsdManager(ManagedSystem system)
        {
            System = system;
        }

        public void SetupSystem()
        {
            using var sshClient = SshManager.CreateSshClient(System);
            using var keyGenerator = new SshKeyGenerator(4096);
            
            Setup.SetupPortCollection(sshClient, keyGenerator.ToRfcPublicKey(Setup.Username));

            System.SshLogin = Setup.Username;
            System.OneTimePassword = null;
            System.SshPrivateKey = keyGenerator.ToPrivateKey();
        }

        public Dictionary<string, string> GetSystemInformation()
        {
            using var client = SshManager.CreateSshClient(System);

            var packagesActions = ActionsProvider.GetPackagesActions(client).ToList();

            System.PackageActions = packagesActions.Count;
            System.UpdatesFetchedAt = DateTime.Now;
            
            return new Dictionary<string, string>
            {
                { "Hostname", new Hostname().GetHostname(client) },
                { "Logged users", Uptime.CurrentLoggedUsers(client) },
                { "Karnel\nUserland\nRunning", $"{SystemVersion.GetKarnel(client)}{SystemVersion.GetUserland(client)}{SystemVersion.GetRunning(client)}" },
                { "Vulnerable packages", Audit.GetVulnerablePackages(client) },
                { $"Packages actions ({System.PackageActions})", string.Join("\n", packagesActions)},
            };
        }

        public void PreparePackagesActions(List<object> actions)
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
            else if (scheduledAction.ScheduledActionType == ScheduledActionType.System)
            {
                SystemUpdate.ExecuteUpdate(client, scheduledAction);
            }
        }

        public string GetScheduledActionDetails(ScheduledAction scheduledAction)
        {
            using var client = SshManager.CreateSshClient(System);
            return Screen.GetScreenOutput(client, scheduledAction);
        }

        public List<PackageInformation> GetPackagesList()
        {
            using var client = SshManager.CreateSshClient(System);
            return Audit.ListAllPackages(client);
        }

        public SystemUpdateInfo GetSystemUpdateInfo()
        {
            using var client = SshManager.CreateSshClient(System);
            return SystemUpdate.GetUpdateInfo(client);
        }

        public List<object> GetPackagesActions()
        {
            using var client = SshManager.CreateSshClient(System);
            var actions = ActionsProvider.GetPackagesActions(client);
            return new List<object>(actions);
        }
    }
}