using System;
using System.Threading;
using Paco.Entities.Models.Updating;
using Renci.SshNet;

namespace Paco.SystemManagement.FreeBsd.Commands
{
    public static class Packages
    {
        public static void UpdatePackages(SshClient sshClient, ScheduledAction scheduledAction)
        {
            var nscdStop = "";
            var nscdStart = "";

            var resultKey = $"{scheduledAction.FreeBsdSessionName} finished with result ";
            
            if ("sudo /usr/sbin/service nscd status".ExecuteCommand(sshClient).Response.Contains("nscd is running as pid"))
            {
                nscdStart = " ; sudo /usr/sbin/service nscd start";
                nscdStop = "sudo /usr/sbin/service nscd stop ; ";
            }

            if (!Screen.Exists(sshClient, scheduledAction))
            {
                Screen.StartScheduledActionCommand(sshClient, scheduledAction, $"{nscdStop} PAGER=cat echo \"y\" | sudo portmaster -ad ; echo {resultKey}$? {nscdStart}");
            }

            while (Screen.Exists(sshClient, scheduledAction))
            {
                Thread.Sleep(10000);
            }

            var success = sshClient.CreateCommand($"tail -n 100 {scheduledAction.FreeBsdLogPath} | grep \"{resultKey}\"").Execute().Replace(resultKey, "").Trim() == "0";

            if (!success)
            {
                throw new ApplicationException($"Packages action execution of {scheduledAction.ManagedSystem.Name} was unsuccessful.");
            }
        }
    }
}