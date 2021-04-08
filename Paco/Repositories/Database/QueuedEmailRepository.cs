using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Paco.Entities.Models;
using Paco.Entities.Models.Identity;

namespace Paco.Repositories.Database
{
    public static class QueuedEmailRepository
    {
        public static List<QueuedEmail> GetAllUnsentEmails(this DbSet<QueuedEmail> queuedEmails)
        {
            return queuedEmails.Where(x => !x.WasSent).Include(x => x.Recipients).ToList();
        }
    }
}