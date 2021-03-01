using System;
using Microsoft.AspNetCore.Identity;

namespace Paco.Data.Entities.Identity
{
    public class UserRole : IdentityUserRole<Guid>, IDbEntity
    {
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public User User { get; set; }
        public Role Role { get; set; }
    }
}
