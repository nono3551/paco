using System;
using System.Linq;

namespace Paco.Entities.FreeBsd
{
    public class PackageAction
    {
        public ActionType ActionType { get; set;  }
        public string Description { get; set; }
        public string NewVersion { get; set; }
        public string CurrentVersion { get; set; }
        public string CollectionRoot { get; set; }
        public string DbRoot => CollectionRoot.Replace("/", "_").Replace("_usr_ports_", "/var/db/ports/");

        public override string ToString()
        {
            return Description;
        }
    }
}