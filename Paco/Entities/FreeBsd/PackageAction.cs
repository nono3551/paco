﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis.Options;

namespace Paco.Entities.FreeBsd
{
    public class PackageAction
    {
        public ActionType ActionType { get; init;  }
        public string Description { get; init; }
        public string NewVersion { get; init; }
        public string CurrentVersion { get; init; }
        public string CollectionRoot { get; init; }
        public string DbRoot { get; init; }

        public List<PackageOption> SimpleOptions { get; init; }

        public List<PackageOptionsGroup> OptionsGroups { get; init; }

        public override string ToString()
        {
            return Description;
        }

        public List<PackageOption> AllOptions
        {
            get
            {
                var result = new List<PackageOption>();
                result.AddRange(SimpleOptions);
                result.AddRange(OptionsGroups.SelectMany(packageOptionsGroup => packageOptionsGroup.Options));
                return result;
            }
        }

        public void SetUndefinedOptionsAsUnset()
        {
            var undefinedOptions = AllOptions.Where(x => x.Status == OptionSetStatus.Undefined).ToList();
            
            foreach (var option in undefinedOptions)
            {
                option.Status = OptionSetStatus.Unset;
            }
        }

        public List<string> GetOptionsProblems()
        {
            var problems = new List<string>();

            var undefinedOptions = AllOptions.Where(x => x.Status == OptionSetStatus.Undefined).ToList();

            if (undefinedOptions.Any())
            {
                problems.Add($"Has new undefined options: {string.Join(",", undefinedOptions.Select(x => x.Name))}");
            }

            foreach (var @group in OptionsGroups)
            {
                var groupProblem = @group.GetProblem();
                if (groupProblem != null)
                {
                    problems.Add(groupProblem);
                }
            }

            return problems;
        }
    }
}