using Paco.Data;
using Paco.Data.Entities;
using System;
using System.Text.Json;

namespace Paco.Services
{
    public class SystemManagerService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly object _lock = new object();

        public SystemManagerService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void RefreshSystemInformation(ManagedSystem system)
        {
            var systemInformation = system.GetDistributionManager().GetSystemInformation();

            system.LastAccessed = DateTime.UtcNow;
            system.SystemInformation = JsonSerializer.Serialize(systemInformation);

            lock(_lock)
            {
                _dbContext.Update(system);
                _dbContext.SaveChanges();
            }
        }

        public void FetchSystemUpdates(ManagedSystem system)
        {
            system.GetDistributionManager().FetchSystemUpdates();

            system.LastAccessed = DateTime.UtcNow;
            system.UpdatesFetchedAt = DateTime.UtcNow;

            lock (_lock)
            {
                _dbContext.Update(system);
                _dbContext.SaveChanges();
            }
        }
    }
}
