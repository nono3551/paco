using System;
using System.Collections.Generic;
using System.Linq;
using Paco.Entities;
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

        public static string GetVulnerablePackageDetails(SshClient sshClient, string packageName)
        {
            var detail = sshClient.CreateCommand($"sudo pkg audit -F -r -q {packageName}").Execute();

            return detail;
        }
        
        public static KeyValuePair<bool, string> PackagesActionsNeedsInteraction(SshClient sshClient)
        {
            var result = "sudo portmaster -L".ExecuteCommand(sshClient);
            
            return new KeyValuePair<bool, string>(!result.Success, result.Response);
        }

        public static void UpdatePortsCollection(SshClient sshClient)
        {
            sshClient.CreateCommand("sudo portsnap fetch update --interactive").Execute();
        }

        public static List<PackageInformation> ListAllPackages(SshClient sshClient)
        {
            var packages = sshClient.CreateCommand("sudo pkg info").Execute().Split("\n", StringSplitOptions.RemoveEmptyEntries);
            
            var packageInformation = packages.Select(package =>
            {
                var endOfPackageName = package.IndexOf(" ", StringComparison.Ordinal);
                var name = package.Substring(0, endOfPackageName).Trim();
                var description = package.Substring(endOfPackageName).Trim();

                return new PackageInformation()
                {
                    Name = name,
                    Description = description
                };
            }).ToList();

            return packageInformation;
        }
    }
}