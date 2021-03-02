using System;
using System.Collections.Generic;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using Paco.Entities.Models;
using Paco.Repositories.Database;

namespace Paco.Services
{
    public class SystemManagerService
    {
        private static readonly object Lock = new object();

        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger _logger;

        public SystemManagerService(ApplicationDbContext dbContext, ILoggerFactory loggerFactory)
        {
            _dbContext = dbContext;
            _logger = loggerFactory.CreateLogger<SystemManagerService>();
        }

        public void RefreshSystemInformation(ManagedSystem system)
        {
            Dictionary<string, string> systemInformation = null;
            bool updateNeedsInteraction = false;
            string interactionReason = null;

            ExecuteWorkWithSystem(system, managedSystem =>
            {
                var distribution = managedSystem.GetDistributionManager();
                systemInformation = distribution.GetSystemInformation();
                (updateNeedsInteraction, interactionReason) = distribution.UpdateNeedsInteraction();
            }, managedSystem =>
            {
                managedSystem.SystemInformation = JsonSerializer.Serialize(systemInformation);
                managedSystem.NeedsInteraction &= updateNeedsInteraction;
                managedSystem.InteractionReason = $"{managedSystem.NeedsInteraction}\n{interactionReason}";
            });
        }

        public void FetchSystemUpdates(ManagedSystem system)
        {
            _logger.LogInformation("Fetching update for {system}.", system.Name);

            ExecuteWorkWithSystem(system, managedSystem =>
            {
                managedSystem.GetDistributionManager().FetchSystemUpdates();
            }, managedSystem =>
            {
                managedSystem.UpdatesFetchedAt = DateTime.UtcNow;
            });
        }

        private void ExecuteWorkWithSystem(ManagedSystem system, Action<ManagedSystem> work, Action<ManagedSystem> updateSystem)
        {
            lock (Lock)
            {
                try
                {
                    work(system);

                    _dbContext.Entry(system).Reload();

                    system.LastAccessed = DateTime.UtcNow;
                    updateSystem(system);
                }
                catch (Exception e)
                {
                    _dbContext.Entry(system).Reload();

                    system.NeedsInteraction = true;
                    system.InteractionReason = $"{system.InteractionReason}\n{e.Message}";

                    _logger.LogError(e, "While executing work with {system}: {exception}", system.Name, e.Message);
                }

                _dbContext.Update(system);
                _dbContext.SaveChanges();
            }
        }
    }
}
