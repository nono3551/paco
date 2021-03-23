using System.Threading;
using Paco.Entities.Models.Updating;
using Renci.SshNet;

namespace Paco.SystemManagement.FreeBsd.Commands
{
    public static class Packages
    {
        private static string GetLogFile(this ScheduledAction action)
        {
            return $"/tmp/{action.GetSessionName()}.log";
        }
        
        private static string GetSessionName(this ScheduledAction action)
        {
            return $"paco.update.{action.Id}";
        }

        public static void UpdatePackages(SshClient sshClient, ScheduledAction scheduledAction)
        {
            
            var nscdStop = "";
            var nscdStart = "";
            
            if ("sudo /usr/sbin/service nscd status".ExecuteCommand(sshClient).Response.Contains("nscd is running as pid"))
            {
                nscdStart = "; sudo /usr/sbin/service nscd start ;";
                nscdStop = "; sudo /usr/sbin/service nscd stop ;";
            }

            if (!StillUpdating(sshClient, scheduledAction.GetSessionName()))
            {
                sshClient.CreateCommand($"screen -dmS {scheduledAction.GetSessionName()} -L -Logfile {scheduledAction.GetLogFile()} sh -c '{nscdStop} echo \"y\" | sudo portmaster -ad {nscdStart}'" ).Execute();
            }

            while (StillUpdating(sshClient, scheduledAction.GetSessionName()))
            {
                Thread.Sleep(10000);
            }
        }

        private static bool StillUpdating(SshClient sshClient, string sessionName)
        {
            return sshClient.CreateCommand("screen -list").Execute().Contains(sessionName);
        }

        public static string GetScheduledActionDetail(SshClient sshClient, ScheduledAction scheduledAction)
        {
            return sshClient.CreateCommand($"tail -n 10 {scheduledAction.GetLogFile()} | sed -r \"s/\\x1B\\[([0-9]{{1,2}}(;[0-9]{{1,2}})?)?[mGK]//g\" | sed \"s/\\x0f//g\"").Execute();
        }
    }
}