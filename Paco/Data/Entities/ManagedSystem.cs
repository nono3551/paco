using Paco.SystemManagement;
using Paco.SystemManagement.FreeBsd;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Paco.Data.Entities
{
    public class ManagedSystem : IDbEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Hostname { get; set; }
        public string Login { get; set; } 
        public string Password { get; set; }
        public string SystemInformation { get; set; }
        public string SystemFingerprint { get; set; }
        public string SshPrivateKey { get; set; }
        public DateTime? LastAccessed { get; set; }
        public DateTime? UpdatesFetchedAt { get; set; }
        public DateTime? CreatedAt { get ; set ; }
        public DateTime? UpdatedAt { get ; set ; }
        public DateTime? DeletedAt { get ; set ; }
        public Distribution Distribution { get; set; }
        [DefaultValue(false)]
        public bool NeedsInteraction { get; set; }
        public string InteractionReason { get; set; }

        public ISystemManager GetDistributionManager()
        {
            return new FreeBsdManager(this);
        }
    }
}
