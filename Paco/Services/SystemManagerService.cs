﻿using System;
using System.Collections.Generic;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Paco.Entities;
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

        public void AddSystem(ManagedSystem managedSystem)
        {
            managedSystem.GetDistributionManager().SetupSystem();
            
            _dbContextFactory.Upsert(managedSystem);
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
                (updateNeedsInteraction, interactionReason) = distribution.PackagesActionsNeedsInteraction();
            }, managedSystem =>
            {
                managedSystem.SystemInformation = JsonSerializer.Serialize(systemInformation);
                managedSystem.HasProblems &= updateNeedsInteraction;
                managedSystem.ProblemDescription = $"{managedSystem.HasProblems}\n\n{DateTime.UtcNow}\n{interactionReason}".Trim();
            });
        }

        public List<object> GetPackagesActions(ManagedSystem system)
        {
            _logger.LogInformation("Getting packages actions for {system}.", system.Name);

            List<object> updates = null;
            
            ExecuteWorkWithSystem(system, managedSystem =>
            {
                updates = managedSystem.GetDistributionManager().GetPackagesActions();
            }, managedSystem =>
            {
                managedSystem.UpdatesFetchedAt = DateTime.UtcNow;
            });

            return updates;
        }
        
        public List<PackageInformation> GetPackagesList(ManagedSystem system)
        {
            _logger.LogInformation("Getting packages list for {system}.", system.Name);

            List<PackageInformation> updates = null;
            
            ExecuteWorkWithSystem(system, managedSystem =>
            {
                updates = managedSystem.GetDistributionManager().GetPackagesList();
            }, managedSystem =>
            {
                
            });

            return updates;
        }
        
        public void ExecuteScheduledAction(ScheduledAction update)
        {
            _logger.LogInformation("Starting scheduled action {actionId}.", update.Id);

            ExecuteWorkWithSystem(update.ManagedSystem, managedSystem =>
            {
                if (update.ScheduledActionStatus == ScheduledActionStatus.Queued)
                {
                    update.ScheduledActionStatus = ScheduledActionStatus.Started;
                    update.StartedAt = DateTime.Now;
                }
                
                _dbContextFactory.Upsert(update);
                
                managedSystem.GetDistributionManager().ExecuteScheduledAction(update);
            }, managedSystem =>
            {
                update.ScheduledActionStatus = ScheduledActionStatus.Successful;
                _dbContextFactory.Upsert(update);
            }, managedSystem =>
            {
                update.ScheduledActionStatus = ScheduledActionStatus.Failure;
                _dbContextFactory.Upsert(update);
            });
        }

        public void PreparePackagesActions(ManagedSystem system, List<object> actions)
        {
            _logger.LogInformation("Preparing packages actions for {system}.", system.Name);
            
            ExecuteWorkWithSystem(system, managedSystem =>
            {
                managedSystem.GetDistributionManager().PreparePackagesActions(actions);
            }, managedSystem =>
            {
                
            });
        }

        public string GetUpdateDetails(ScheduledAction scheduledAction)
        {
            var result = "Could not retrieve scheduled action details.";
            
            ExecuteWorkWithSystem(scheduledAction.ManagedSystem, system =>
            {
                var manager = scheduledAction.ManagedSystem.GetDistributionManager();
                result = manager.GetScheduledActionDetails(scheduledAction);
            }, system =>
            {
                
            });

            return result;
        }
        
        private void ExecuteWorkWithSystem(ManagedSystem system,
            Action<ManagedSystem> action,
            Action<ManagedSystem> onSuccess,
            Action<ManagedSystem> onFailure = null)
        {
            using var dbContext = _dbContextFactory.CreateDbContext();

            try
            {
                action(system);

                dbContext.Entry(system).Reload();

                system.HasProblems = false;

                system.LastAccessed = DateTime.UtcNow;
                onSuccess(system);
            }
            catch (Exception e)
            {
                dbContext.Entry(system).Reload();

                system.HasProblems = true;
                system.ProblemDescription = $"{system.ProblemDescription}\n\n {DateTime.UtcNow}\n{e.Message}".Trim();

                _logger.LogError(e, "While executing work with {system}: {exception}", system.Name, e.Message);

                onFailure?.Invoke(system);

                throw;
            }
            finally
            {
                dbContext.Update(system);
                dbContext.SaveChanges();
            }
        }
    }
}
