using System.IO;
using System.Threading;
using Renci.SshNet;

namespace Paco.SystemManagement.FreeBsd.Commands
{
    public static class Update
    {
        public static void UpdatePackages(SshClient sshClient)
        {
            var sessionName = "paco.update";

            if (!StillUpdating(sshClient, sessionName))
            {
                //sshClient.CreateCommand($"screen -dmS {sessionName} -L -Logfile /tmp/{sessionName}.log sh -c 'echo \"y\" | sudo portmaster -ad'").Execute();
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