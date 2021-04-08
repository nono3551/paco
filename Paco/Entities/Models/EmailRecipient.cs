using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Paco.Entities.Models.Identity;

namespace Paco.Entities.Models
{
    public class EmailRecipient: IDbEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Guid QueuedEmailId { get; set; }
        public Guid UserId { get; set; }
        
        public DateTime? DeletedAt { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public User Recipient { get; set; }
        public QueuedEmail QueuedEmail { get; set; }
    }
}