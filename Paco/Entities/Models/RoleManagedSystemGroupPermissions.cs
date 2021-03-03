using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Paco.Entities.Models.Identity;

namespace Paco.Entities.Models
{
    public class RoleManagedSystemGroupPermissions : IDbEntity, IPermissionsEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Guid RoleId { get; set; }
        public Guid ManagedSystemGroupId { get; set; }
        public Permissions Permissions { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        
        public ManagedSystemGroup ManagedSystemGroup { get; set; }
        public Role Role { get; set; }
    }
}
