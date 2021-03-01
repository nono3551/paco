using System;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.AspNetCore.Identity;

namespace Paco.Data.Entities.Identity
{
    public class User : IdentityUser<Guid>, IDbEntity
    {
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
        public List<Role> Roles { get; set; }
        public List<UserRole> UserRoles { get; set; }
    }
}
