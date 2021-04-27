using System;
using System.Collections.Generic;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Paco.Entities;
using Paco.Entities.Models;
using Paco.Entities.Models.Updating;
using Paco.Repositories.Database;
using Paco.SystemManagement;
using Paco.SystemManagement.FreeBsd;

namespace Paco.Services
{
    public class SystemManagerService
    {
        private IDbContextFactory<ApplicationDbContext> DbContextFactory { get; }
        private ILogger Logger { get; }

        public SystemManagerService(IDbContextFactory<ApplicationDbContext> dbContextFactory, ILoggerFactory loggerFactory)
        {
            DbContextFactory = dbContextFactory;
            Logger = loggerFactory.CreateLogger<SystemManagerService>();
        }

        public void AddSystem(ManagedSystem managedSystem)
        {
            GetDistributionManager(managedSystem).SetupSystem();
            
            DbContextFactory.Upsert(managedSystem);
        }

        public void RefreshSystemInformation(ManagedSystem system)
        {
            Logger.LogInformation("Refreshing system information for {system}.", system.Name);

            Dictionary<string, string> systemInformation = null;

            ExecuteWorkWithSystem(system, managedSystem =>
            {
                systemInformation = GetDistributionManager(managedSystem).GetSystemInformation();
            }, managedSystem =>
            {
                managedSystem.SystemInformation = JsonSerializer.Serialize(systemInformation);
            });
        }

        public List<object> GetPackagesActions(ManagedSystem system)
        {
            Logger.LogInformation("Getting packages actions for {system}.", system.Name);

            List<object> updates = null;
            
            ExecuteWorkWithSystem(system, managedSystem =>
            {
                updates = GetDistributionManager(managedSystem).GetPackagesActions();
            }, managedSystem =>
            {
                managedSystem.UpdatesFetchedAt = DateTime.UtcNow;
            });

            return updates;
        }
        
        public List<PackageInformation> GetListOfPackages(ManagedSystem system)
        {
            Logger.LogInformation("Getting packages list for {system}.", system.Name);

            List<PackageInformation> updates = null;
            
            ExecuteWorkWithSystem(system, managedSystem =>
            {
                updates = GetDistributionManager(managedSystem).GetListOfPackages();
            }, managedSystem =>
            {
                
            });

            return updates;
        }
        
        public void ExecuteScheduledAction(ScheduledAction update)
        {
            Logger.LogInformation("Starting scheduled action {actionId}.", update.Id);

            ExecuteWorkWithSystem(update.ManagedSystem, managedSystem =>
            {
                if (update.ScheduledActionStatus == ScheduledActionStatus.Queued)
                {
                    update.ScheduledActionStatus = ScheduledActionStatus.Started;
                    update.StartedAt = DateTime.Now;
                }
                
                DbContextFactory.Upsert(update);
                
                GetDistributionManager(managedSystem).ExecuteScheduledAction(update);
            }, managedSystem =>
            {
                update.ScheduledActionStatus = ScheduledActionStatus.Successful;
                DbContextFactory.Upsert(update);
            }, managedSystem =>
            {
                update.ScheduledActionStatus = ScheduledActionStatus.Failure;
                DbContextFactory.Upsert(update);
            });
        }

        public void PreparePackagesActions(ManagedSystem system, List<object> actions)
        {
            Logger.LogInformation("Preparing packages actions for {system}.", system.Name);
            
            ExecuteWorkWithSystem(system, managedSystem =>
            {
                GetDistributionManager(managedSystem).PreparePackagesActions(actions);
            }, managedSystem =>
            {
                
            });
        }

        public string GetScheduledActionDetails(ScheduledAction scheduledAction)
        {
            var result = "Could not retrieve scheduled action details.";
            
            ExecuteWorkWithSystem(scheduledAction.ManagedSystem, system =>
            {
                var manager = GetDistributionManager(scheduledAction.ManagedSystem);
                result = manager.GetScheduledActionDetails(scheduledAction);
            }, system =>
            {
                
            });

            return result;
        }
        
        private void ExecuteWorkWithSystem(ManagedSystem system,
            Action<ManagedSystem> action,
            Action<ManagedSystem> onSuccess = null,
            Action<ManagedSystem> onFailure = null)
        {
            using var dbContext = DbContextFactory.CreateDbContext();

            try
            {
                action(system);

                dbContext.Entry(system).Reload();
                
                system.LastAccessed = DateTime.UtcNow;
                onSuccess?.Invoke(system);
            }
            catch (Exception e)
            {
                dbContext.Entry(system).Reload();

                system.AddProblem($"{system.ProblemDescription}\n\n {DateTime.UtcNow}\n{e.Message}".Trim());
                
                Logger.LogError(e, "While executing work with {system}: {exception}", system.Name, e.Message);

                onFailure?.Invoke(system);

                throw;
            }
            finally
            {
                dbContext.Update(system);
                dbContext.SaveChanges();
            }
        }

        public SystemUpdateInfo GetInformationAboutSystemUpdate(ManagedSystem system)
        {
            Logger.LogInformation("Getting update info for {system}.", system.Name);
                
            SystemUpdateInfo updateInfo = null;
            
            ExecuteWorkWithSystem(system, managedSystem =>
            {
                updateInfo = GetDistributionManager(managedSystem).GetInformationAboutSystemUpdate();
            });

            return updateInfo;
        }

        public void ScheduleAction(ScheduledAction scheduledAction)
        {
            DbContextFactory.Upsert(scheduledAction);
        }
        
        private ISystemManager GetDistributionManager(ManagedSystem managedSystem)
        {
            return new FreeBsdManager(DbContextFactory, managedSystem);
        }
    }
}
