using System;

namespace Paco.Entities.FreeBsd
{
    [Flags]
    public enum OptionSetStatus
    {
        Undefined = 1,
        PackageSet = 2,
        PackageUnset = 4,
        GloballySet = 8,
        GloballyUnset = 16,
        IsSet = GloballySet | PackageSet,
        IsUnset = GloballyUnset | Undefined | PackageUnset
    }
}