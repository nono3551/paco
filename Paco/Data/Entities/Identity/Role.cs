using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Paco.Data.Entities.Identity
{
    public class Role : IdentityRole<Guid>, IDbEntity
    {
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public IEnumerable<RoleSystemPermission> SystemsPermissions { get; set; }
    }
}
