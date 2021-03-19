using System;
using System.Collections.Generic;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Paco.Entities.Models;
using Paco.Entities.Models.Updating;
using Paco.Repositories.Database;

namespace Paco.Services
{
    public class SystemManagerService
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory;
        private readonly ILogger _logger;

        public SystemManagerService(IDbContextFactory<ApplicationDbContext> dbContextFactory, ILoggerFactory loggerFactory)
        {
            _dbContextFactory = dbContextFactory;
            _logger = loggerFactory.CreateLogger<SystemManagerService>();
        }

        public void RefreshSystemInformation(ManagedSystem system)
        {
            _logger.LogInformation("Refreshing system information for {system}.", system.Name);

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

        public IEnumerable<object> GetPackagesActions(ManagedSystem system, bool shouldRefresh = false)
        {
            _logger.LogInformation("Getting packages actions for {system}.", system.Name);

            IEnumerable<object> updates = null;
            
            ExecuteWorkWithSystem(system, managedSystem =>
            {
                updates = managedSystem.GetDistributionManager().GetPackagesActions();
            }, managedSystem =>
            {
                if (shouldRefresh)
                {
                    managedSystem.UpdatesFetchedAt = DateTime.UtcNow;
                }
            });

            return updates;
        }
        
        public void UpdatePackages(SystemUpdate update)
        {
            _logger.LogInformation("Updating {system} packages.", update.ManagedSystem.Name);

            ExecuteWorkWithSystem(update.ManagedSystem, managedSystem =>
            {
                update.UpdateStatus = UpdateStatus.Started;
                update.StartedAt = DateTime.Now;
                _dbContextFactory.Upsert(update);
                
                managedSystem.GetDistributionManager().UpdatePackages(update);
            }, managedSystem =>
            {
                update.UpdateStatus = UpdateStatus.Successful;
                _dbContextFactory.Upsert(update);
            }, managedSystem =>
            {
                update.UpdateStatus = UpdateStatus.Failure;
            });
        }

        public void PreparePackagesActions(ManagedSystem system, IEnumerable<object> actions)
        {
            _logger.LogInformation("Preparing packages actions for {system}.", system.Name);
            
            ExecuteWorkWithSystem(system, managedSystem =>
            {
                managedSystem.GetDistributionManager().PreparePackagesActions(actions);
            }, managedSystem =>
            {
                
            }, null, true);
        }

        private void ExecuteWorkWithSystem(ManagedSystem system,
            Action<ManagedSystem> action,
            Action<ManagedSystem> onSuccess,
            Action<ManagedSystem> onFailure = null,
            bool shouldThrow = false)
        {
            using var dbContext = _dbContextFactory.CreateDbContext();
                
            try
            { 
                action(system);

                dbContext.Entry(system).Reload();
                    
                system.NeedsInteraction = false;

                system.LastAccessed = DateTime.UtcNow;
                onSuccess(system);
            }
            catch (Exception e)
            {
                dbContext.Entry(system).Reload();

                system.NeedsInteraction = true;
                system.InteractionReason = $"{system.InteractionReason}\n{e.Message}";

                _logger.LogError(e, "While executing work with {system}: {exception}", system.Name, e.Message);

                onFailure?.Invoke(system);
                
                if (shouldThrow)
                {
                    throw;
                }
            }

            dbContext.Update(system);
            dbContext.SaveChanges();
        }
    }
}
