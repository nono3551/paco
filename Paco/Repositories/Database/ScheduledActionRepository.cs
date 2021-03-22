using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Paco.Entities.Models;
using Paco.Entities.Models.Updating;

namespace Paco.Repositories.Database
{
    public static class ScheduledActionRepository
    {
        public static List<ScheduledAction> GetQueuedAndStartedScheduledActions(this DbSet<ScheduledAction> updates)
        {
            return updates
                .Where(x => x.ScheduledAt <= DateTime.Now && (x.ScheduledActionStatus == ScheduledActionStatus.Queued || x.ScheduledActionStatus == ScheduledActionStatus.Started))
                .Include(x => x.ManagedSystem)
                .ToList();
        }
        
        public static List<ScheduledAction> GetQueuedAndStartedScheduledActionsForSystem(this DbSet<ScheduledAction> updates, ManagedSystem managedSystem)
        {
            return updates
                .Where(x => managedSystem.Id == x.ManagedSystemId && x.ScheduledAt <= DateTime.Now && (x.ScheduledActionStatus == ScheduledActionStatus.Queued || x.ScheduledActionStatus == ScheduledActionStatus.Started))
                .Include(x => x.ManagedSystem)
                .ToList();
        }
        
        public static List<ScheduledAction> GetScheduledActionsForSystem(this DbSet<ScheduledAction> updates, ManagedSystem managedSystem)
        {
            return updates
                .Where(x => managedSystem.Id == x.ManagedSystemId)
                .Include(x => x.ManagedSystem)
                .ToList();
        }
    }
}