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
        public List<RoleSystemPermission> SystemsPermissions { get; set; }
        public List<User> Users { get; set; }
        public List<UserRole> UserRoles { get; set; }
    }
}
