using System;
using System.ComponentModel;
using Microsoft.AspNetCore.Identity;

namespace Paco.Data.Entities.Identity
{
    public class RoleClaim : IdentityRoleClaim<Guid>, IDbEntity
    {
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
    }
}
