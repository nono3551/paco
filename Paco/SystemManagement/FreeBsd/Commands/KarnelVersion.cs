using Renci.SshNet;

namespace Paco.SystemManagement.FreeBsd.Commands
{
    public class KarnelVersion
    {
        public string GetUserland(SshClient sshClient) => sshClient.CreateCommand("freebsd-version -u").Execute();
        public string GetRunning(SshClient sshClient) => sshClient.CreateCommand("freebsd-version -r").Execute();
        public string GetKarnel(SshClient sshClient) => sshClient.CreateCommand("freebsd-version -k").Execute();
    }
}
