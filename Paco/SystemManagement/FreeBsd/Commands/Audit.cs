using Renci.SshNet;

namespace Paco.SystemManagement.FreeBsd.Commands
{
    public class Audit
    {
        public void GetAudit(SshClient sshClient)
        {
            var auditOutput = sshClient.CreateCommand("sudo pkg audit -F -r").Execute();
            var auditResult = sshClient.CreateCommand("echo -n $?").Execute();

            if (auditResult == "0")
            {

            }

        }
    }
}
