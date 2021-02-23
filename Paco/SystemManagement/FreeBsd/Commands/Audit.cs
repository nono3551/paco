using System;
using System.Collections.Generic;
using System.Linq;
using Renci.SshNet;

namespace Paco.SystemManagement.FreeBsd.Commands
{
    public static class Audit
    {
        public static string GetVulnerablePackages(SshClient sshClient, bool detailed = false)
        {
            var auditOutput = sshClient.CreateCommand($"sudo pkg audit -F -r {(detailed ? "" : "-q")}").Execute();

            if (!detailed)
            {
                auditOutput = string.Join("\n", auditOutput.Split("\n\n").Select(packageInfo => packageInfo.Split("\n").First()));
            }

            return auditOutput;
        }

        public static string GetVulnerablePackageDetail(SshClient sshClient, string packageName)
        {
            var detail = sshClient.CreateCommand($"sudo pkg audit -F -r -q {packageName}").Execute();

            return detail;
        }

        public static KeyValuePair<bool, string> UpdateNeedsInteraction(SshClient sshClient)
        {
            var reason = sshClient.CreateCommand("sudo portmaster -Ld ; echo $?").Execute();
            var needs = reason.Replace("\n\n", "\n").Split('\n').Last(x => !string.IsNullOrEmpty(x)) == "1";

            return  new KeyValuePair<bool, string>(needs, reason);
        }
    }
}
