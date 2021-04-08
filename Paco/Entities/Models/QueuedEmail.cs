using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Paco.Entities.Models.Identity;

namespace Paco.Entities.Models
{
    public class QueuedEmail: IDbEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string Body { get; set; }
        public string Subject { get; set; }
        [DefaultValue(false)]
        public bool WasSent { get; set; }
        public DateTime? SentAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        
        public List<User> Recipients { get; set; }
        public List<EmailRecipient> EmailRecipients { get; set; }
    }
}