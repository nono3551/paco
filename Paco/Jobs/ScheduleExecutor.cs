using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Paco.Entities.Models.Identity;
using Paco.Entities.Models.Updating;
using Paco.Repositories.Database;
using Paco.Services;
using Timer = System.Threading.Timer;

namespace Paco.Jobs
{
    public class ScheduleExecutor : IHostedService
    {
        private readonly object _lock = new();
        private readonly List<Guid> _startedActions = new();
        private readonly ILogger<ScheduleExecutor> _logger;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private Timer _timer;

        public ScheduleExecutor(ILogger<ScheduleExecutor> logger, IServiceScopeFactory serviceScopeFactory)
        {
            _logger = logger;
            _serviceScopeFactory = serviceScopeFactory;
        }

        public Task StartAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Timed Hosted Service running.");
            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(60));
            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            try
            {
                _logger.LogInformation("Schedule execution started.");

                using IServiceScope workScope = _serviceScopeFactory.CreateScope();

                SystemManagerService manager = workScope
                    .ServiceProvider
                    .GetRequiredService<SystemManagerService>();

                var dbContext = workScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                var updates = dbContext.ScheduledActions.GetQueuedAndStartedScheduledActions();
                var administrators = dbContext.Users.GetAllAdministrators();
                var emailQueueService = workScope.ServiceProvider.GetService<EmailQueueService>();

                _logger.LogInformation($"Scheduler found {updates.Count()} actions.");

                Parallel.ForEach(updates, async (update) =>
                {
                    var alreadyWatching = false;
                    try
                    {
                        lock (_lock)
                        {
                            if (!_startedActions.Contains(update.Id))
                            {
                                _startedActions.Add(update.Id);
                            }
                            else
                            {
                                alreadyWatching = true;
                            }
                        }

                        if (!alreadyWatching)
                        {
                            await Task.Run(() =>
                            {
                                emailQueueService?.ScheduledActionEmail(update);
                                manager.ExecuteScheduledAction(update);
                            });
                        }
                    }
                    catch (Exception exception)
                    {
                        _logger.LogError(exception, "While trying to execute update {updateId}: {exception}", update.Id, exception.Message);
                    }

                    if (!alreadyWatching)
                    {
                        lock (_lock)
                        {
                            _startedActions.Remove(update.Id);
                            emailQueueService?.ScheduledActionEmail(update);
                        }
                    }
                });
            }
            catch (Exception e)
            {
                _logger.LogError("Schedule executor failed. {exception}", e.Message);
            }
        }


        public Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Update fetcher is stopping.");

            _timer?.Change(Timeout.Infinite, 0);
            _timer?.Dispose();

            return Task.CompletedTask;
        }
    }
}