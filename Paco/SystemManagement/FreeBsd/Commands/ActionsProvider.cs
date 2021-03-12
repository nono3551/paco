using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Paco.Entities.FreeBsd;
using Renci.SshNet;

namespace Paco.SystemManagement.FreeBsd.Commands
{
    public static class ActionsProvider
    {
        private const string PortDirectoryKey = "===>>> Port directory: ";
        private const string PortNameKey = "PORTNAME";
        private const string DistVersionKey = "DISTVERSION";
        private const string PortVersionKey = "PORTVERSION";
        private const string PortRevisionKey = "PORTREVISION";
        private const string PortEpochKey = "PORTEPOCH";
        private const string CategoriesKey = "CATEGORIES";
        private const string OptionsDefinitionKey = "OPTIONS_DEFINE";
        private const string DescriptionSuffix = "DESC";
        private const string StartOfPackageActionInformationKey = "===>>> Launching child to ";
        private const string OptionsFileSetKey = "OPTIONS_FILE_SET";
        private const string OptionsFileUnsetKey = "OPTIONS_FILE_UNSET";
        private const string OptionsGloballySetKey = "OPTIONS_SET";
        private const string OptionsGloballyUnsetKey = "OPTIONS_UNSET";
        
        private static readonly Dictionary<string, OptionsGroupType> OptionsGroupTypesMapping = new()
        {
            {"OPTIONS_SINGLE", OptionsGroupType.Single},
            {"OPTIONS_RADIO", OptionsGroupType.Radio},
            {"OPTIONS_MULTI", OptionsGroupType.Multi},
            {"OPTIONS_GROUP", OptionsGroupType.Group}
        };

        public static IEnumerable<PackageAction> GetPackagesActions(SshClient sshClient, bool shouldRefresh = false)
        {
            if (shouldRefresh)
            {
                Audit.UpdatePortsCollection(sshClient);
            }

            var fullCommandOutput = sshClient.CreateCommand("echo n | sudo portmaster -aGn").Execute();
            var indexOfStart = fullCommandOutput.IndexOf(StartOfPackageActionInformationKey, StringComparison.Ordinal);
            var packagesActionsInformation = fullCommandOutput.Substring(indexOfStart).Split(StartOfPackageActionInformationKey, StringSplitOptions.RemoveEmptyEntries);

            var actions = new List<PackageAction>();

            var makeConf = sshClient.CreateCommand($"cat /etc/make.conf").Execute();

            foreach (var portMasterInformation in packagesActionsInformation)
            {
                var actionType = Enum.Parse<ActionType>(portMasterInformation.Split(" ").First(), true);
                var collectionRoot = portMasterInformation.Split(PortDirectoryKey).Last().Split("\n", StringSplitOptions.RemoveEmptyEntries).First().Split("@").First();
                var dbRoot = collectionRoot.Replace("/", "_").Replace("_usr_ports_", "/var/db/ports/");
                var description = portMasterInformation.Split("\n").First();

                var makefile = sshClient.CreateCommand($"cat {collectionRoot}/Makefile").Execute();
                var portOptionsFile = sshClient.CreateCommand($"cat {dbRoot}/options").Execute();

                string currentVersion;
                var newVersion = ParseNewVersion(makefile);
                
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
                    SimpleOptions = ParseOptions(makefile, portOptionsFile, makeConf),
                    OptionsGroups = ParseOptionsGroups(makefile, portOptionsFile, makeConf)
                });
            }

            return actions;
        }

        private static List<PackageOptionsGroup> ParseOptionsGroups(string makefile, string portOptionsFile, string makeConf)
        {
            var groups = new List<PackageOptionsGroup>();
            
            var globallySetOptions = new List<string>();
            var globallyUnsetOptions = new List<string>();

            GetValueFromFile(makeConf, OptionsGloballySetKey)?.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList().ForEach(globallySetOptions.Add);
            GetValueFromFile(makeConf, OptionsGloballyUnsetKey)?.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList().ForEach(globallyUnsetOptions.Add);

            foreach (var (key, value) in OptionsGroupTypesMapping)
            {
                var optionsKeys = GetValueFromFile(makefile, key)?.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                
                if (optionsKeys != null)
                {
                    foreach (var groupOptionsKey in optionsKeys)
                    {
                        var groupOptionsKeys = GetValueFromFile(makefile, $"{key}_{groupOptionsKey}").Split(" ");
                        
                        var groupOptions = groupOptionsKeys.Select(option => new PackageOption()
                        {
                            Name = option,
                            Status = ParseOptionSetStatus(portOptionsFile, globallySetOptions, globallyUnsetOptions, option),
                            Description = GetDescription(makefile, option)
                        }).ToList();

                        groups.Add(new PackageOptionsGroup()
                        {
                            Options = groupOptions,
                            OptionsGroupType = value,
                            Name = groupOptionsKey,
                            Description = GetDescription(makefile, groupOptionsKey)
                        });
                    }
                }
            }
            
            return groups;
        }
        

        private static string ParseNewVersion(string makefile)
        {
            string newVersion = null;

            var startOfParameters = makefile.IndexOf(PortNameKey, StringComparison.Ordinal);
            var startOfCategories = makefile.IndexOf(CategoriesKey, StringComparison.Ordinal);
            var packageNameParameters = makefile.Substring(startOfParameters, startOfCategories - startOfParameters);

            //Name
            if (packageNameParameters.Contains(PortNameKey))
            {
                newVersion = packageNameParameters.Split(PortNameKey).Last().Split("\n").First().Split("=").Last().Trim();
            }

            //PortVersion
            if (packageNameParameters.Contains(PortVersionKey))
            {
                newVersion = $"{newVersion}-{packageNameParameters.Split(PortVersionKey).Last().Split("\n").First().Split("=").Last().Trim()}";
            }

            //DistVersion
            if (packageNameParameters.Contains(DistVersionKey))
            {
                newVersion = $"{newVersion}-{packageNameParameters.Split(DistVersionKey).Last().Split("\n").First().Split("=").Last().Trim()}";
            }

            //Revision
            if (packageNameParameters.Contains(PortRevisionKey))
            {
                var revision = packageNameParameters.Split(PortRevisionKey).Last().Split("\n").First().Split("=").Last().Trim();

                if (revision != "0")
                {
                    newVersion = $"{newVersion}_{revision}";
                }
            }

            //PortEpoch
            if (packageNameParameters.Contains(PortEpochKey))
            {
                var epoch = packageNameParameters.Split(PortEpochKey).Last().Split("=").Last().Trim();

                if (epoch != "0")
                {
                    newVersion = $"{newVersion},{epoch}";
                }
            }

            return newVersion;
        }

        private static List<PackageOption> ParseOptions(string makefile, string portOptionsFile, string makeConf)
        {
            var options = new List<PackageOption>();
            var optionsKeys = new List<string>();
            var globallySetOptions = new List<string>();
            var globallyUnsetOptions = new List<string>();

            GetValueFromFile(makefile, OptionsDefinitionKey)?.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList().ForEach(optionsKeys.Add);
            GetValueFromFile(makeConf, OptionsGloballySetKey)?.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList().ForEach(globallySetOptions.Add);
            GetValueFromFile(makeConf, OptionsGloballyUnsetKey)?.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList().ForEach(globallyUnsetOptions.Add);

            foreach (var optionKey in optionsKeys)
            {
                options.Add(new PackageOption()
                {
                    Description = GetDescription(makefile, optionKey),
                    Name = optionKey,
                    Status = ParseOptionSetStatus(portOptionsFile, globallySetOptions, globallyUnsetOptions, optionKey)
                });
            }

            return options;
        }

        private static string GetDescription(string makefile, string optionKey)
        {
            return GetValueFromFile(makefile, $"{optionKey}_{DescriptionSuffix}");
        }

        private static OptionSetStatus ParseOptionSetStatus(string portOptionsFile, IEnumerable<string> globallySetOptions, IEnumerable<string> globallyUnsetOptions, string optionsKey)
        {
            var state = OptionSetStatus.Undefined;

            if (HasOptionInOptionsFile(portOptionsFile, optionsKey, false))
            {
                state = OptionSetStatus.Unset;
            }
            else if (HasOptionInOptionsFile(portOptionsFile, optionsKey, true))
            {
                state = OptionSetStatus.Set;
            }
            else if (globallySetOptions.Contains(optionsKey))
            {
                state = OptionSetStatus.Set;
            }
            else if (globallyUnsetOptions.Contains(optionsKey))
            {
                state = OptionSetStatus.Unset;
            }

            return state;
        }

        private static string GetValueFromFile(string file, string key)
        {
            var lineWithValue = file.Replace("\\\n", "").Replace("\t", "").Split("\n").FirstOrDefault(x => x.StartsWith(key));
            var result = lineWithValue?.Split("=").Last().Trim();
            return result;
        }

        private static bool HasOptionInOptionsFile(string optionsFile, string optionKey, bool lookingForSet)
        {
            var result = Regex.Match(optionsFile,
                $@"{(lookingForSet ? OptionsFileSetKey : OptionsFileUnsetKey)}(=|\+=){optionKey}"
            ).Success;

            return result;
        }
    }
}