using System;
using Microsoft.AspNetCore.Identity;

namespace Paco.Data.Identity
{
    public class Role : IdentityRole<Guid>
    {
        public string NewField { get; set; }
    }
}
