using System;
using Microsoft.AspNetCore.Identity;
using Paco.Data.Entities;

namespace Paco.Data.Identity
{
    public class User : IdentityUser<Guid>, IDbEntity
    {
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
