using System;
using Microsoft.AspNetCore.Identity;

namespace Paco.Entities.Models.Identity
{
    public class UserToken : IdentityUserToken<Guid>, IDbEntity
    {
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        
        public DateTime? DeletedAt { get; set; }
    }
}
