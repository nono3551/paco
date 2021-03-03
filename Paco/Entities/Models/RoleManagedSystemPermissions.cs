using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Paco.Entities.Models.Identity;

namespace Paco.Entities.Models
{
    public class RoleManagedSystemPermissions: IDbEntity, IPermissionsEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
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
