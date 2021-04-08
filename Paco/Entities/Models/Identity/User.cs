using System;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.AspNetCore.Identity;
using Paco.Entities.Models.Updating;

namespace Paco.Entities.Models.Identity
{
    public class User : IdentityUser<Guid>, IDbEntity
    {
        [DefaultValue(true)] 
        public bool EmailNotifications { get; set; } = true;
        
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        
        public List<Role> Roles { get; set; }
        public List<UserRole> UserRoles { get; set; }
        public List<QueuedEmail> QueuedEmails { get; set; }
        public List<EmailRecipient> EmailRecipientUser { get; set; }
        public List<ScheduledAction> ActionsScheduled { get; set; }
    }
}
