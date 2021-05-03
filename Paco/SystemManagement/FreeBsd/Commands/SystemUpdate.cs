using System;
using Renci.SshNet;
using System.Linq;
using System.Threading;
using Paco.Entities;
using Paco.Entities.Models.Updating;
using Serilog;

namespace Paco.SystemManagement.FreeBsd.Commands
{
    public static class SystemUpdate
    {
        private static string GetLatestMinorVersion(SshClient sshClient)
        {

            var runningVersionOnly = sshClient.CreateCommand("sudo freebsd-version | cut -d \"-\" -f 1").Execute().Replace("\n", "");
            var latestVersion = sshClient.CreateCommand($"fetch -qo - http://svn.freebsd.org/base/releng/{runningVersionOnly}/sys/conf/newvers.sh | grep -E \"TYPE|REVISION|BRANCH\" | head -3").Execute();

            var currentRevision = latestVersion.Split("\n").FirstOrDefault(line => line.Contains("REVISION"))?.Split("\"")[1];
            var currentBranch = latestVersion.Split("\n").FirstOrDefault(line => line.Contains("BRANCH"))?.Split("\"")[1];

            var latest = $"{currentRevision}-{currentBranch}";

            return latest;
        }

        private static string GetLatestVersion(SshClient sshClient)
        {
            var latestVersion = sshClient.CreateCommand("fetch -qo - http://svn.freebsd.org/base/releng/ | grep li | grep -v '\\.\\.' | grep -v 'ALPHA' | grep -v 'BETA' | cut -d \\\" -f 2 | sed 's/\\///g' | sort -n | tail -n 1").Execute().Replace("\n", "");
            return latestVersion;
        }

        public static SystemUpdateInfo GetUpdateInfo(SshClient sshClient)
        {
            var info = new SystemUpdateInfo();

            var running = sshClient.CreateCommand("sudo freebsd-version").Execute().Replace("\n", "");

            var latestMinorVersion = GetLatestMinorVersion(sshClient);

            var runningVersionOnly = sshClient.CreateCommand("sudo freebsd-version | cut -d \"-\" -f 1").Execute().Replace("\n", "");

            var latestVersion = GetLatestVersion(sshClient);

            info.CurrentVersion = running;
            
            if (running != latestMinorVersion)
            {
                info.Description = $"Update {running} to {latestMinorVersion}";
                info.CanUpdate = true;
                info.HasUpdate = true;
                info.NewVersion = latestMinorVersion;
            }
            else if (runningVersionOnly != latestVersion)
            {
                info.Description = $"{info.Description} \n System has new version {latestVersion} available. Major version updates are not supported in PACO.";
                info.HasUpdate = true;
            }

            info.Description = info.Description?.Trim();
            
            return info;
        }

        public static void ExecuteUpdate(SshClient sshClient, ScheduledAction scheduledAction)
        {
            var resultKey = $"{scheduledAction.FreeBsdSessionName} finished with result ";

            if (!Screen.Exists(sshClient, scheduledAction))
            {
                Screen.StartScheduledActionCommand(sshClient, scheduledAction, $"PAGER=cat sudo freebsd-update fetch ; sudo freebsd-update install ; echo {resultKey}$?");
            }

            while (Screen.Exists(sshClient, scheduledAction))
            {
                Thread.Sleep(10000);
            }

            var success = sshClient.CreateCommand($"tail -n 10 {scheduledAction.FreeBsdLogPath} | grep \"{resultKey}\"").Execute().Replace(resultKey, "").Trim() == "0";

            var fullOutput = sshClient.CreateCommand($"cat {scheduledAction.FreeBsdLogPath}").Execute();
            
            Log.Information($"Scheduled action {scheduledAction.Id} full output: {fullOutput}");
            
            if (!success)
            {
                throw new ApplicationException($"System update of {scheduledAction.ManagedSystem.Name} was unsuccessful.");
            }
        }
    }
}