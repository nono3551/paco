using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Paco.Entities.Models;
using Paco.Entities.Models.Identity;
using Paco.Entities.Models.Updating;
using Paco.Repositories.Database;

namespace Paco.Services
{
    public class EmailQueueService
    {
        private IDbContextFactory<ApplicationDbContext> DbContextFactory { get; }

        public EmailQueueService(IDbContextFactory<ApplicationDbContext> dbContextFactory)
        {
            DbContextFactory = dbContextFactory;
        }

        private void QueueEmail(string subject, string body, params User[] recipients)
        {
            var queuedEmail = new QueuedEmail
            {
                Body = body,
                Subject = subject
            };
            
            DbContextFactory.Upsert(queuedEmail);

            foreach (var recipient in recipients)
            {
                DbContextFactory.Upsert(new EmailRecipient()
                {
                    UserId = recipient.Id,
                    QueuedEmailId = queuedEmail.Id
                });
            }
        }

        public void ScheduledActionEmail(ScheduledAction scheduledAction)
        {
            var body =
                $"<p>Scheduled action's status was changed.</p><table class=\"table\"><tbody><tr><td>New status</td><td>{scheduledAction.ScheduledActionStatus}</td></tr><tr><td>Action type</td><td>{scheduledAction.ScheduledActionType}</td></tr><tr><td>System name</td><td>{scheduledAction.ManagedSystem.Name}</td></tr><tr><td>Time</td><td>{DateTime.UtcNow}</td></tr></tbody></table>";

            var subject = $"[ACTION-{scheduledAction.ScheduledActionType}-{scheduledAction.ScheduledActionStatus}] {scheduledAction.ManagedSystem.Name}";

            QueueEmail(subject, body, GetRecipientsForScheduledAction(scheduledAction));
        }
        
        private User[] GetRecipientsForScheduledAction(ScheduledAction scheduledAction)
        {
            var context = DbContextFactory.CreateDbContext();
            var administrators = context.Users.GetAllAdministrators();
            
            var recipients = new List<User>(administrators);
            if (scheduledAction.ScheduledBy.EmailNotifications && recipients.All(x => x.Id != scheduledAction.ScheduledBy.Id))
            {
                recipients.Add(scheduledAction.ScheduledBy);
            }

            return recipients.ToArray();
        }
    }
}
