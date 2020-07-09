using System;
using Microsoft.AspNetCore.Identity;
using Paco.Data.Entities;

namespace Paco.Data.Identity
{
    public class UserToken : IdentityUserToken<Guid>, IDbEntity
    {
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
