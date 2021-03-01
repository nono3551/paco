﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.AspNetCore.Identity;

namespace Paco.Data.Entities.Identity
{
    public class Role : IdentityRole<Guid>, IDbEntity
    {
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
        public List<RoleSystemPermissions> SystemsPermissions { get; set; }
        public List<User> Users { get; set; }
        public List<UserRole> UserRoles { get; set; }
    }
}
