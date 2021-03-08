using System;
using System.Collections.Generic;
using System.Linq;
using Paco.SystemManagement.Ssh;
using Renci.SshNet;

namespace Paco.SystemManagement.FreeBsd.Commands
{
    public static class Audit
    {
        public static string GetVulnerablePackages(SshClient sshClient, bool detailed = false)
        {
            var auditOutput = sshClient.CreateCommand($"pkg audit -F -r {(detailed ? "" : "-q")}").Execute();

            if (!detailed)
            {
                auditOutput = string.Join("\n", auditOutput.Split("\n\n").Select(packageInfo => packageInfo.Split("\n").First()));
            }

            return auditOutput;
        }

        public static string GetVulnerablePackageDetail(SshClient sshClient, string packageName)
        {
            var detail = sshClient.CreateCommand($"pkg audit -F -r -q {packageName}").Execute();

            return detail;
        }

        public static KeyValuePair<bool, string> UpdateNeedsInteraction(SshClient sshClient)
        {
            var reason = sshClient.CreateCommand("portmaster -L ; echo $?").Execute();
            var needs = reason.Replace("\n\n", "\n").Split('\n').Last(x => !string.IsNullOrEmpty(x)) != "0";

            return  new KeyValuePair<bool, string>(needs, reason);
        }

        public static void FetchPackagesUpdates(SshClient sshClient)
        {
            sshClient.CreateCommand("portsnap fetch update --interactive").Execute();
        }

        public static IEnumerable<string> GetPackagesUpdates(SshClient sshClient, bool shouldRefresh = false)
        {
            var startOfUpdatesKey = "===>>> The following actions will be taken if you choose to proceed:\n";
            var endOfUpdatesKey = "\n\n";
            
            if (shouldRefresh)
            {
                FetchPackagesUpdates(sshClient);
            }
            
            var result = sshClient.CreateCommand("echo n | portmaster -aGn").Execute();
            var updates = result.Split(startOfUpdatesKey).Last().Split(endOfUpdatesKey).First().Split("\n").Select(x => x.Replace("\t", ""));
            
            return updates;
        }
    }
}
