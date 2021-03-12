using System;

namespace Paco.Entities.FreeBsd
{
    [Flags]
    public enum OptionSetStatus
    {
        Undefined = 1,
        Set = 2,
        Unset = 4,
        IsUnset = Unset | Undefined
    }
}