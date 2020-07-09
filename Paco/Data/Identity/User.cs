using System;
using Microsoft.AspNetCore.Identity;

namespace Paco.Data.Identity
{
    public class User : IdentityUser<Guid>
    {
        public string CustomProperty { get; set; }
    }
}
