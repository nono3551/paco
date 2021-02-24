using System;
using Paco.Data.Entities.Identity;

namespace Paco.Data.Entities
{
    public class RoleSystemPermission: IDbEntity
    {
        public Guid RoleId { get; set; }
        public Guid ManagedSystemId { get; set; }
        public Permissions Permissions { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public Role Role { get; set; }
        public ManagedSystem ManagedSystem { get; set; }
    }
}
