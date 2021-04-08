using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Paco.Entities.Models.Identity;

namespace Paco.Entities.Models.Updating
{
    public class ScheduledAction : IDbEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Guid ManagedSystemId { get; set; }
        public Guid ScheduledById { get; set; }
        public DateTime ScheduledAt { get; set; }
        public DateTime? StartedAt { get; set; }
        [DefaultValue(ScheduledActionStatus.Queued)]
        public ScheduledActionStatus ScheduledActionStatus { get; set; }
        public ScheduledActionType ScheduledActionType { get; set; }
        public DateTime? CreatedAt { get ; set ; }
        public DateTime? UpdatedAt { get ; set ; }
        public DateTime? DeletedAt { get ; set ; }
        
        public ManagedSystem ManagedSystem { get; set; }
        public User ScheduledBy { get; set;  }

        public string FreeBsdSessionName => $"paco.{Id}";
        public string FreeBsdLogPath => $"/tmp/{FreeBsdSessionName}.log";
    }
}