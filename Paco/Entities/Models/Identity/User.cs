﻿using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Paco.Entities.Models.Identity
{
    public class User : IdentityUser<Guid>, IDbEntity
    {
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        
        public DateTime? DeletedAt { get; set; }
        public List<Role> Roles { get; set; }
        public List<UserRole> UserRoles { get; set; }
    }
}