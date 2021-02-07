using Paco.Data;
using Paco.Data.Entities;
using System;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using Paco.Logging;

namespace Paco.Services
{
    public class SystemManagerService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly object _lock = new object();
        private readonly ILogger _logger;

        public SystemManagerService(ApplicationDbContext dbContext, ILoggerFactory loggerFactory)
        {
            _dbContext = dbContext;
            _logger = loggerFactory.CreateLogger<SystemManagerService>();
        }

        public void RefreshSystemInformation(ManagedSystem system)
        {
            var distribution = system.GetDistributionManager();
            try
            {
                var systemInformation = distribution.GetSystemInformation();
                var needsInteraction = distribution.NeedsInteraction();

                system.LastAccessed = DateTime.UtcNow;
                system.SystemInformation = JsonSerializer.Serialize(systemInformation);
                system.NeedsInteraction = needsInteraction.Key;
                system.InteractionReason = needsInteraction.Value;
            }
            catch (Exception e)
            {
                system.NeedsInteraction = true;
                system.InteractionReason = $"{system.InteractionReason}\n{e.Message}";

                _logger.LogError(e, "While trying to get managed system information: {exception}", e.Message);
            }

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
