using System;
using System.Collections.Generic;
using System.Linq;
using Paco.Entities.FreeBsd;
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
                auditOutput = string.Join("\n",
                    auditOutput.Split("\n\n").Select(packageInfo => packageInfo.Split("\n").First()));
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

            return new KeyValuePair<bool, string>(needs, reason);
        }

        public static void FetchPackagesActions(SshClient sshClient)
        {
            sshClient.CreateCommand("portsnap fetch update --interactive").Execute();
        }

        public static IEnumerable<PackageAction> GetPackagesActions(SshClient sshClient, bool shouldRefresh = false)
        {
            var startOfPackageActionInformationKey = "===>>> Launching child to ";
            var startOfUpdatesKey = "===>>> The following actions will be taken if you choose to proceed:\n";
            var endOfUpdatesKey = "\n\n";

            if (shouldRefresh)
            {
                FetchPackagesActions(sshClient);
            }

            var fullCommandOutput = sshClient.CreateCommand("echo n | portmaster -aGn").Execute();
            var indexOfStart = fullCommandOutput.IndexOf(startOfPackageActionInformationKey, StringComparison.Ordinal);
            var packagesActionsInformation = fullCommandOutput.Substring(indexOfStart).Split(startOfPackageActionInformationKey, StringSplitOptions.RemoveEmptyEntries);

            var actions = new List<PackageAction>();

            foreach (var portMasterInformation in packagesActionsInformation)
            {
                var portDirectoryKey = "===>>> Port directory: ";
                var distVersionKey = "DISTVERSION=\t";
                var portVersionKey = "PORTVERSION=\t";
                var portRevisionKey = "PORTREVISION=\t";
                var portEpochKey = "PORTEPOCH=\t";

                var actionType = Enum.Parse<ActionType>(portMasterInformation.Split(" ").First(), true);
                var collectionRoot = portMasterInformation.Split(portDirectoryKey).Last().Split("\n", StringSplitOptions.RemoveEmptyEntries).First();
                var description = portMasterInformation.Split("\n").First();

                var makefile = sshClient.CreateCommand($"cat {collectionRoot}/Makefile").Execute();
                string currentVersion = null;
                string newVersion = null;

                if (makefile.Contains(portVersionKey))
                {
                    newVersion = makefile.Split(portVersionKey).Last().Split("\n").First();
                }
                
                if (makefile.Contains(distVersionKey))
                {
                    newVersion = makefile.Split(distVersionKey).Last().Split("\n").First();
                }

                if (makefile.Contains(portRevisionKey))
                {
                    newVersion = $"{newVersion}_{makefile.Split(portRevisionKey).Last().Split("\n").First()}";
                }

                if (makefile.Contains(portEpochKey))
                {
                    newVersion = $"{newVersion},{makefile.Split(portEpochKey).Last().Split("\n").First()}";
                }

                switch (actionType)
                {
                    case ActionType.Install:
                        currentVersion = null;
                        break;
                    case ActionType.Reinstall:
                        currentVersion = newVersion;
                        break;
                    case ActionType.Update:
                        currentVersion = portMasterInformation.Split(" ")[1];
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                
                actions.Add(new PackageAction()
                {
                    Description = description,
                    ActionType = actionType,
                    CollectionRoot = collectionRoot,
                    CurrentVersion = currentVersion,
                    NewVersion = newVersion,
                });
            }

            return actions;
        }
    }
}