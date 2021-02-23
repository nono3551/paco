using System;
using Microsoft.AspNetCore.Identity;

namespace Paco.Data.Entities.Identity
{
    public class Role : IdentityRole<Guid>, IDbEntity
    {
        public string NewField { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
