using System;
using System.Collections.Generic;
using System.Linq;
using Paco.Entities.FreeBsd;
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
            var portDirectoryKey = "===>>> Port directory: ";
            var distVersionKey = "DISTVERSION=\t";
            var portVersionKey = "PORTVERSION=\t";
            var portRevisionKey = "PORTREVISION=\t";
            var portEpochKey = "PORTEPOCH=\t";
            var optionsDefinitionKey = "OPTIONS_DEFINE=\t";
            var descriptionSuffix = "_DESC=\t";
            var optionsFileSetKey = "OPTIONS_FILE_SET+=";
            var optionsFileUnsetKey = "OPTIONS_FILE_UNSET+=";
            var startOfPackageActionInformationKey = "===>>> Launching child to ";
            var optionsGloballySetKey = "OPTIONS_SET+=";
            var optionsGloballyUnsetKey = "OPTIONS_UNSET+=";

            if (shouldRefresh)
            {
                FetchPackagesActions(sshClient);
            }

            var fullCommandOutput = sshClient.CreateCommand("echo n | portmaster -aGn").Execute();
            var indexOfStart = fullCommandOutput.IndexOf(startOfPackageActionInformationKey, StringComparison.Ordinal);
            var packagesActionsInformation = fullCommandOutput.Substring(indexOfStart).Split(startOfPackageActionInformationKey, StringSplitOptions.RemoveEmptyEntries);

            var actions = new List<PackageAction>();

            var makeConf = sshClient.CreateCommand($"cat /etc/make.conf").Execute();

            var globallySetOptions = new List<string>();
            var globallyUnsetOptions = new List<string>();

            if (makeConf.Contains(optionsGloballySetKey))
            {
                globallySetOptions.AddRange(makeConf.Split(optionsGloballySetKey)[1].Split("\n").First().Split(" ", StringSplitOptions.RemoveEmptyEntries));
            }

            if (makeConf.Contains(optionsGloballyUnsetKey))
            {
                globallyUnsetOptions.AddRange(makeConf.Split(optionsGloballyUnsetKey)[1].Split("\n").First().Split(" ", StringSplitOptions.RemoveEmptyEntries));
            }
            
            foreach (var portMasterInformation in packagesActionsInformation)
            {
                var actionType = Enum.Parse<ActionType>(portMasterInformation.Split(" ").First(), true);
                var collectionRoot = portMasterInformation.Split(portDirectoryKey).Last().Split("\n", StringSplitOptions.RemoveEmptyEntries).First();
                var dbRoot = collectionRoot.Replace("/", "_").Replace("_usr_ports_", "/var/db/ports/");
                var description = portMasterInformation.Split("\n").First();

                var makefile = sshClient.CreateCommand($"cat {collectionRoot}/Makefile").Execute();
                var portOptions = sshClient.CreateCommand($"cat {dbRoot}/options").Execute();

                string currentVersion;
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

                var optionsKeys = new List<string>();

                if (makefile.Contains(optionsDefinitionKey))
                {
                    optionsKeys.AddRange(makefile.Split(optionsDefinitionKey)[1].Split("\n").First().Split(" "));
                }

                var options = new List<PackageOption>();
                
                foreach (var optionsKey in optionsKeys)
                {
                    var descriptionKey = $"{optionsKey}{descriptionSuffix}";
                    string optionDescription = null;

                    if (makefile.Contains(descriptionKey))
                    {
                        optionDescription = makefile.Split(descriptionKey).Last().Split("\n").First();
                    }

                    var state = OptionSetStatus.Undefined;
                    
                    if (portOptions.Contains($"{optionsFileUnsetKey}{optionsKey}"))
                    {
                        state = OptionSetStatus.PackageUnset;
                    }
                    else if (portOptions.Contains($"{optionsFileSetKey}{optionsKey}"))
                    {
                        state = OptionSetStatus.PackageSet;
                    }
                    else if (globallySetOptions.Contains(optionsKey))
                    {
                        state = OptionSetStatus.GloballySet;
                    }
                    else if (globallyUnsetOptions.Contains(optionsKey))
                    {
                        state = OptionSetStatus.GloballyUnset;
                    }
                    
                    options.Add(new PackageOption()
                    {
                        Description = optionDescription,
                        Name = optionsKey,
                        Status = state
                    });
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
                    DbRoot = dbRoot,
                    CurrentVersion = currentVersion,
                    NewVersion = newVersion,
                    Options = options
                });
            }

            return actions;
        }
    }
}