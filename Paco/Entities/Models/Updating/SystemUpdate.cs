using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Paco.Entities.Models.Updating
{
    public class SystemUpdate : IDbEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Guid ManagedSystemId { get; set; }
        public DateTime ScheduledAt { get; set; }
        public DateTime StartedAt { get; set; }
        [DefaultValue(UpdateStatus.Queued)]
        public UpdateStatus UpdateStatus { get; set; }
        public UpdateType UpdateType { get; set; }
        public DateTime? CreatedAt { get ; set ; }
        public DateTime? UpdatedAt { get ; set ; }
        public DateTime? DeletedAt { get ; set ; }
        
        public ManagedSystem ManagedSystem { get; set; }
    }
}