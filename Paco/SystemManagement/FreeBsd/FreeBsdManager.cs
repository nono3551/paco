using System;
using Paco.SystemManagement.FreeBsd.Commands;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Paco.Entities;
using Paco.Entities.Models;
using Paco.Entities.Models.Updating;
using Paco.Repositories.Database;
using Paco.SystemManagement.Ssh;

namespace Paco.SystemManagement.FreeBsd
{
    public class FreeBsdManager : ISystemManager
    {
        private IDbContextFactory<ApplicationDbContext> DbContextFactory { get; }
        private ManagedSystem System { get; }

        public FreeBsdManager(IDbContextFactory<ApplicationDbContext> dbContextFactory, ManagedSystem system)
        {
            DbContextFactory = dbContextFactory;
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
            using var sshClient = SshManager.CreateSshClient(System);
            using var dbContext = DbContextFactory.CreateDbContext();
            var hasNotFinishedScheduledActions = dbContext.ScheduledActions.SystemHasNotFinishedUpdate(System);

            var packagesActions = ActionsProvider.GetPackagesActions(sshClient, hasNotFinishedScheduledActions).ToList();

            var vulnerablePackages = Audit.GetVulnerablePackages(sshClient);
            var systemUpdateInfo = SystemUpdate.GetUpdateInfo(sshClient);
            
            System.PackageActions = packagesActions.Count;
            System.HasSystemUpdateAvailable = systemUpdateInfo.HasUpdate;
            System.UpdatesFetchedAt = DateTime.Now;

            if (!string.IsNullOrEmpty(vulnerablePackages?.Trim()))
            {
                System.AddProblem("Found vulnerable packages!!!");
            }

            var result = new Dictionary<string, string>
            {
                {"Hostname", new Hostname().GetHostname(sshClient)},
                {"Logged users", Uptime.CurrentLoggedUsers(sshClient)},
                {
                    "Karnel\nUserland\nRunning",
                    $"{SystemVersion.GetKarnel(sshClient)}{SystemVersion.GetUserland(sshClient)}{SystemVersion.GetRunning(sshClient)}"
                },
                {"Vulnerable packages", vulnerablePackages},
                {$"Packages actions ({System.PackageActions})", string.Join("\n", packagesActions)},
            };

            if (System.HasSystemUpdateAvailable)
            {
                result.Add("Has system update", System.HasSystemUpdateAvailable.ToString());
            }
            
            return result;
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

        public List<PackageInformation> GetListOfPackages()
        {
            using var client = SshManager.CreateSshClient(System);
            return Audit.ListAllPackages(client);
        }

        public SystemUpdateInfo GetInformationAboutSystemUpdate()
        {
            using var client = SshManager.CreateSshClient(System);
            return SystemUpdate.GetUpdateInfo(client);
        }

        public List<object> GetPackagesActions()
        {
            using var client = SshManager.CreateSshClient(System);
            var actions = ActionsProvider.GetPackagesActions(client, false);
            return new List<object>(actions);
        }
    }
}