using System.IO;
using System.Threading;
using Paco.Entities.Models.Updating;
using Renci.SshNet;

namespace Paco.SystemManagement.FreeBsd.Commands
{
    public static class Update
    {
        public static void UpdatePackages(SshClient sshClient, SystemUpdate systemUpdate)
        {
            var sessionName = $"paco.update.{systemUpdate.Id}";

            if (!StillUpdating(sshClient, sessionName))
            {
                sshClient.CreateCommand($"screen -dmS {sessionName} -L -Logfile /tmp/{sessionName}.log sh -c 'echo \"y\" | sudo portmaster -ad'").Execute();
            }

            while (StillUpdating(sshClient, sessionName))
            {
                Thread.Sleep(10000);
            }
        }

        private static bool StillUpdating(SshClient sshClient, string sessionName)
        {
            return sshClient.CreateCommand("screen -list").Execute().Contains(sessionName);
        }
    }
}