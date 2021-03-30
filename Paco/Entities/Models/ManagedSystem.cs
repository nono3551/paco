using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
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
        public string SshLogin { get; set; }
        public int PackageActions { get; set; }
        [RegularExpression(Fingerprint.FingerprintRegex, ErrorMessage = Fingerprint.FingerprintRegexError)]
        public string SystemFingerprint { get; set; }
        public string SshPrivateKey { get; set; }
        public DateTime? LastAccessed { get; set; }
        public DateTime? UpdatesFetchedAt { get; set; }
        public DateTime? CreatedAt { get ; set ; }
        public DateTime? UpdatedAt { get ; set ; }
        public DateTime? DeletedAt { get ; set ; }
        public Distribution Distribution { get; set; }
        
        public bool HasProblems { get; set; }
        public string ProblemDescription { get; set; }
        public string SystemInformation { get; set; }

        [NotMapped]
        public Fingerprint Fingerprint => new(SystemFingerprint);
        [Required, NotMapped]
        public string OneTimeLogin { get; set; }
        [Required, NotMapped]
        public string OneTimePassword { get; set; }

        public List<ManagedSystemGroup> ManagedSystemGroups { get; set; }
        public List<ManagedSystemManagedSystemGroup> ManagedSystemManagedSystemGroups { get; set; }
        public List<RoleManagedSystemPermissions> RoleManagedSystemPermissions { get; set; }
        public List<ScheduledAction> ScheduledActions { get; set; }

        [NotMapped]
        public Permissions Permissions
        {
            get
            {
                var permissions = ManagedSystemGroups
                    .SelectMany(x => x.RoleManagedSystemGroupPermissions)
                    .Union<IPermissionsEntity>(RoleManagedSystemPermissions).Select(x => x.Permissions);

                var result = permissions.Aggregate(Permissions.None, (x, y) => x | y);
                
                return result;
            }
        }
        
        public ISystemManager GetDistributionManager()
        {
            return new FreeBsdManager(this);
        }
    }
}
