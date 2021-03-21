using System;
using System.Collections.Generic;
using System.Linq;

namespace Paco.Entities.FreeBsd.PackagesActions
{
    public class PackageOptionsGroup
    {
        public OptionsGroupType OptionsGroupType { get; init; }
        public List<PackageOption> Options { get; init; }
        public string Description { get; init; }
        public string Name { get; init; }

        public string GetProblem()
        {
            string error = null;

            switch (OptionsGroupType)
            {
                case OptionsGroupType.Single:
                    if (Options.Count(x => x.OptionSetStatus == OptionSetStatus.Set) != 1)
                    {
                        error = $"Options group {Name} must have only one option checked.";
                    }
                    break;
                case OptionsGroupType.Radio:
                    if (Options.Count(x => x.OptionSetStatus == OptionSetStatus.Set) > 1)
                    {
                        error = $"Options group {Name} must have single option checked."; 
                    }
                    break;
                case OptionsGroupType.Multi:
                    if (Options.Count(x => x.OptionSetStatus == OptionSetStatus.Set) == 0)
                    {
                        error = $"Options group {Name} must have at least one option checked."; 
                    }
                    break;
                case OptionsGroupType.Group:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return error;
        }
    }
}