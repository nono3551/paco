using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Paco.Entities.FreeBsd.PackagesActions;
using Renci.SshNet;

namespace Paco.SystemManagement.FreeBsd.Commands
{
    public static class ActionsProvider
    {
        private const string PortDirectoryKey = "===>>> Port directory: ";
        private const string OptionsDefinitionKey = "OPTIONS_DEFINE";
        private const string DescriptionSuffix = "DESC";
        private const string StartOfPackageActionInformationKey = "===>>> Launching child to ";
        private const string OptionsFileSetKey = "OPTIONS_FILE_SET";
        private const string OptionsFileUnsetKey = "OPTIONS_FILE_UNSET";
        private const string OptionsGloballySetKey = "OPTIONS_SET";
        private const string OptionsGloballyUnsetKey = "OPTIONS_UNSET";
        private const string AllPortsAreUpToDateKey = "All ports are up to date";
        private const string MakefilePackageNameKey = "PKGNAME";

        private static readonly Dictionary<string, OptionsGroupType> OptionsGroupTypesMapping = new()
        {
            {"OPTIONS_SINGLE", OptionsGroupType.Single},
            {"OPTIONS_RADIO", OptionsGroupType.Radio},
            {"OPTIONS_MULTI", OptionsGroupType.Multi},
            {"OPTIONS_GROUP", OptionsGroupType.Group}
        };

        public static List<PackageAction> GetPackagesActions(SshClient sshClient)
        {
            var actions = new List<PackageAction>();

            Audit.UpdatePortsCollection(sshClient);

            var fullCommandOutput = sshClient.CreateCommand("echo n | sudo portmaster -aGn").Execute();
            if (!fullCommandOutput.Contains(AllPortsAreUpToDateKey))
            {
                var indexOfStart = fullCommandOutput.IndexOf(StartOfPackageActionInformationKey, StringComparison.Ordinal);
                var packagesActionsInformation = fullCommandOutput.Substring(indexOfStart).Split(StartOfPackageActionInformationKey, StringSplitOptions.RemoveEmptyEntries);

                var makeConf = sshClient.CreateCommand($"cat /etc/make.conf").Execute();

                foreach (var portMasterInformation in packagesActionsInformation)
                {
                    var actionType = Enum.Parse<PackageActionType>(portMasterInformation.Split(" ").First(), true);
                    var collectionRoot = portMasterInformation.Split(PortDirectoryKey).Last().Split("\n", StringSplitOptions.RemoveEmptyEntries).First().Split("@").First();
                    var dbRoot = collectionRoot.Replace("/", "_").Replace("_usr_ports_", "/var/db/ports/");
                    var description = portMasterInformation.Split("\n").First();

                    var portOptionsFile = sshClient.CreateCommand($"cat {dbRoot}/options").Execute();
                    
                    var newVersion = GetValueFromMakefile(sshClient, collectionRoot, MakefilePackageNameKey);
                    
                    string currentVersion;

                    switch (actionType)
                    {
                        case PackageActionType.Install:
                            currentVersion = null;
                            break;
                        case PackageActionType.Reinstall:
                            currentVersion = newVersion;
                            break;
                        case PackageActionType.Update:
                            currentVersion = portMasterInformation.Split(" ")[1];
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }

                    actions.Add(new PackageAction()
                    {
                        Description = description,
                        PackageActionType = actionType,
                        CollectionRoot = collectionRoot,
                        DbRoot = dbRoot,
                        CurrentVersion = currentVersion,
                        NewVersion = newVersion,
                        SimpleOptions = ParseOptions(sshClient, collectionRoot, portOptionsFile, makeConf),
                        OptionsGroups = ParseOptionsGroups(sshClient, collectionRoot, portOptionsFile, makeConf)
                    });
                }
            }

            return actions;
        }

        private static List<PackageOptionsGroup> ParseOptionsGroups(SshClient sshClient, string collectionRoot, string portOptionsFile, string makeConf)
        {
            var groups = new List<PackageOptionsGroup>();

            var globallySetOptions = new List<string>();
            var globallyUnsetOptions = new List<string>();

            GetValueFromMakeConfFile(makeConf, OptionsGloballySetKey)?.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList().ForEach(globallySetOptions.Add);
            GetValueFromMakeConfFile(makeConf, OptionsGloballyUnsetKey)?.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList().ForEach(globallyUnsetOptions.Add);

            foreach (var (key, value) in OptionsGroupTypesMapping)
            {
                var optionsKeys = GetValueFromMakefile(sshClient, collectionRoot, key)?.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (optionsKeys != null)
                {
                    foreach (var groupOptionsKey in optionsKeys)
                    {
                        var groupOptionsKeys = GetValueFromMakefile(sshClient, collectionRoot, $"{key}_{groupOptionsKey}").Split(" ");

                        var groupOptions = groupOptionsKeys.Select(option => new PackageOption()
                        {
                            Name = option,
                            OptionSetStatus = ParseOptionSetStatus(portOptionsFile, globallySetOptions, globallyUnsetOptions, option),
                            Description = GetDescriptionFromMakefile(sshClient, collectionRoot, option)
                        }).ToList();

                        groups.Add(new PackageOptionsGroup()
                        {
                            Options = groupOptions,
                            OptionsGroupType = value,
                            Name = groupOptionsKey,
                            Description = GetDescriptionFromMakefile(sshClient, collectionRoot, groupOptionsKey)
                        });
                    }
                }
            }

            return groups;
        }

        private static List<PackageOption> ParseOptions(SshClient sshClient, string collectionRoot, string portOptionsFile, string makeConf)
        {
            var options = new List<PackageOption>();
            var optionsKeys = new List<string>();
            var globallySetOptions = new List<string>();
            var globallyUnsetOptions = new List<string>();

            GetValueFromMakefile(sshClient, collectionRoot, OptionsDefinitionKey)?.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList().ForEach(optionsKeys.Add);
            GetValueFromMakeConfFile(makeConf, OptionsGloballySetKey)?.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList().ForEach(globallySetOptions.Add);
            GetValueFromMakeConfFile(makeConf, OptionsGloballyUnsetKey)?.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList().ForEach(globallyUnsetOptions.Add);

            foreach (var optionKey in optionsKeys)
            {
                options.Add(new PackageOption()
                {
                    Description = GetDescriptionFromMakefile(sshClient, collectionRoot, optionKey),
                    Name = optionKey,
                    OptionSetStatus = ParseOptionSetStatus(portOptionsFile, globallySetOptions, globallyUnsetOptions,
                        optionKey)
                });
            }

            return options;
        }

        private static string GetDescriptionFromMakefile(SshClient sshClient, string collectionRoot, string optionKey)
        {
            return GetValueFromMakefile(sshClient, collectionRoot, $"{optionKey}_{DescriptionSuffix}");
        }

        private static OptionSetStatus ParseOptionSetStatus(string portOptionsFile, IEnumerable<string> globallySetOptions, IEnumerable<string> globallyUnsetOptions, string optionsKey)
        {
            var state = OptionSetStatus.Undefined;

            if (HasOptionInOptionsFile(portOptionsFile, optionsKey, false) || globallyUnsetOptions.Contains(optionsKey))
            {
                state = OptionSetStatus.Unset;
            }
            else if (HasOptionInOptionsFile(portOptionsFile, optionsKey, true) || globallySetOptions.Contains(optionsKey))
            {
                state = OptionSetStatus.Set;
            }

            return state;
        }


        private static string GetValueFromMakefile(SshClient sshClient, string collectionRoot, string variableKey)
        {
            var result = sshClient.CreateCommand($"make -C \"{collectionRoot}\" -v {variableKey}").Execute().Trim();

            if (string.IsNullOrEmpty(result))
            {
                result = null;
            }

            return result;
        }
        
        private static string GetValueFromMakeConfFile(string makeConf, string key)
        {
            var lineWithValue = makeConf.Replace("\\\n", "").Replace("\t", "").Split("\n").FirstOrDefault(x => x.StartsWith(key));
            var result = lineWithValue?.Split("=").Last().Trim();
            return result;
        }

        private static bool HasOptionInOptionsFile(string optionsFile, string optionKey, bool lookingForSet)
        {
            var result = Regex.Match(optionsFile, $@"{(lookingForSet ? OptionsFileSetKey : OptionsFileUnsetKey)}(=|\+=){optionKey}").Success;

            return result;
        }
    }
}