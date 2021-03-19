using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Paco.Entities.Models;
using Paco.Entities.Models.Updating;

namespace Paco.Repositories.Database
{
    public static class SystemUpdateRepository
    {
        public static List<SystemUpdate> GetQueuedAndStartedSystemUpdates(this DbSet<SystemUpdate> updates)
        {
            return updates
                .Where(x => x.ScheduledAt <= DateTime.Now && (x.UpdateStatus == UpdateStatus.Queued || x.UpdateStatus == UpdateStatus.Started))
                .Include(x => x.ManagedSystem)
                .ToList();
        }
    }
}