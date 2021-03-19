using Renci.SshNet;

namespace Paco.SystemManagement.FreeBsd.Commands
{
    public static class SystemVersion
    {
        public static string GetUserland(SshClient sshClient) => sshClient.CreateCommand("sudo freebsd-version -u").Execute();
        public static string GetRunning(SshClient sshClient) => sshClient.CreateCommand("sudo freebsd-version -r").Execute();
        public static string GetKarnel(SshClient sshClient) => sshClient.CreateCommand("sudo freebsd-version -k").Execute();
    }
}
