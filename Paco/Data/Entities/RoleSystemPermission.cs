using System;

namespace Paco.Data.Entities
{
    public class RoleSystemPermission: IDbEntity
    {
        public Guid RoleId { get; set; }
        public Guid SystemId { get; set; }
        public Permissions Permissions { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
