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
        public static List<SystemUpdate> GetQueuedSystemUpdates(this DbSet<SystemUpdate> updates)
        {
            return updates
                .Where(x => x.ScheduledAt <= DateTime.Now && x.UpdateStatus == UpdateStatus.Queued)
                .Include(x => x.ManagedSystem)
                .ToList();
        }
    }
}