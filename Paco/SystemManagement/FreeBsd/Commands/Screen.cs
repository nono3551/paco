using Paco.Entities.Models.Updating;
using Renci.SshNet;

namespace Paco.SystemManagement.FreeBsd.Commands
{
    public static class Screen
    {
        public static bool Exists(SshClient sshClient, ScheduledAction scheduledAction)
        {
            return sshClient.CreateCommand("screen -list").Execute().Contains(scheduledAction.FreeBsdSessionName);
        }

        public static string GetScreenOutput(SshClient sshClient, ScheduledAction scheduledAction)
        {
            return sshClient.CreateCommand($"tail -n 10 {scheduledAction.FreeBsdLogPath} | sed -r \"s/\\x1B\\[([0-9]{{1,2}}(;[0-9]{{1,2}})?)?[mGK]//g\" | sed \"s/\\x0f//g\"").Execute();
        }

        public static void StartScheduledActionCommand(SshClient sshClient, ScheduledAction scheduledAction, string command)
        {
            sshClient.CreateCommand($"screen -dmS {scheduledAction.FreeBsdSessionName} -L -Logfile {scheduledAction.FreeBsdLogPath} sh -c '{command}'" ).Execute();
        }
    }
}