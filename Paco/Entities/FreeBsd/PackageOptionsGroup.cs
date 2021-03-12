using System.Collections.Generic;

namespace Paco.Entities.FreeBsd
{
    public class PackageOptionsGroup
    {
        public OptionsGroupType OptionsGroupType { get; init; }
        public IEnumerable<PackageOption> Options { get; init; }
        public string Description { get; init; }
    }
}