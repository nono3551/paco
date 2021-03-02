using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Paco.Entities.Models.Identity;

namespace Paco.Entities.Models
{
    public class ManagedSystemGroup : IDbEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        
        public List<ManagedSystemManagedSystemGroup> ManagedSystemManagedSystemGroups { get; set; }
        public List<RoleManagedSystemGroupPermissions> RoleManagedSystemGroupPermissions { get; set; }
        public List<ManagedSystem> ManagedSystems { get; set; }
        public List<Role> Roles { get; set; }
    }
}
