using System;
using System.Collections.Generic;
using System.Linq;

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

        public IEnumerable<PackageOption> Options { get; init; }
        
        public override string ToString()
        {
            return Description;
        }
    }
}