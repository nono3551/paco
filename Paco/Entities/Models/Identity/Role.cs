using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Paco.Entities.Models.Identity
{
    public class Role : IdentityRole<Guid>, IDbEntity
    {
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public List<RoleManagedSystemPermissions> RoleManagedSystemPermissions { get; set; }
        public List<RoleManagedSystemGroupPermissions> RoleManagedSystemGroupPermissions { get; set; }
        public List<User> Users { get; set; }
        public List<UserRole> UserRoles { get; set; }
        public List<ManagedSystemGroup> ManagedSystemGroups { get; set; }
    }
}