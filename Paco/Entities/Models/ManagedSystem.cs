using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Paco.Entities.Models.Updating;
using Paco.SystemManagement;
using Paco.SystemManagement.FreeBsd;
using Paco.SystemManagement.Ssh;

namespace Paco.Entities.Models
{
    public class ManagedSystem : IDbEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Hostname { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        public string SystemInformation { get; set; }
        [Required]
        [RegularExpression(Fingerprint.FingerprintRegex, ErrorMessage = Fingerprint.FingerprintRegexError)]
        public string SystemFingerprint { get; set; }
        public string SshPrivateKey { get; set; }
        public DateTime? LastAccessed { get; set; }
        public DateTime? UpdatesFetchedAt { get; set; }
        public DateTime? CreatedAt { get ; set ; }
        public DateTime? UpdatedAt { get ; set ; }
        public DateTime? DeletedAt { get ; set ; }
        public Distribution Distribution { get; set; }
        
        public bool NeedsInteraction { get; set; }
        public string InteractionReason { get; set; }

        [NotMapped]
        public Fingerprint Fingerprint => new Fingerprint(SystemFingerprint);

        public List<ManagedSystemGroup> ManagedSystemGroups { get; set; }
        public List<ManagedSystemManagedSystemGroup> ManagedSystemManagedSystemGroups { get; set; }
        public List<RoleManagedSystemPermissions> RoleManagedSystemPermissions { get; set; }
        public List<SystemUpdate> SystemUpdates { get; set; }

        public ISystemManager GetDistributionManager()
        {
            return new FreeBsdManager(this);
        }
    }
}
