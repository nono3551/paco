using System;

namespace Paco.Data.Entities
{
    [Flags]
    public enum Permissions : short
    {
        None = 0,
        Read = 1,
        Write = 2,
        Execute = 4,
    };
}
