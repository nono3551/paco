using System.Collections.Generic;

namespace Paco.Entities.FreeBsd
{
    public class PackageOptionsGroup
    {
        public OptionsGroupType OptionsGroupType { get; set; }
        public IEnumerable<PackageOption> Options { get; set; }
    }
}