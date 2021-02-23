﻿using System;
using Microsoft.AspNetCore.Identity;

namespace Paco.Data.Entities.Identity
{
    public class UserLogin : IdentityUserLogin<Guid>, IDbEntity
    {
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
