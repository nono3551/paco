using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Paco.Entities.Models;
using Paco.Entities.Models.Updating;
using Paco.Repositories.Database;
using Paco.Services;
using Timer = System.Threading.Timer;

namespace Paco.Jobs
{
    public class Updater : IHostedService
    {
        private readonly ILogger<Updater> _logger;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private Timer _timer;

        public Updater(ILogger<Updater> logger, IServiceScopeFactory serviceScopeFactory)
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
                _logger.LogInformation("Update fetcher started.");

                using IServiceScope workScope = _serviceScopeFactory.CreateScope();
                
                SystemManagerService manager = workScope
                    .ServiceProvider
                    .GetRequiredService<SystemManagerService>();
                
                var updates = workScope
                    .ServiceProvider
                    .GetRequiredService<ApplicationDbContext>()
                    .SystemUpdates
                    .GetQueuedSystemUpdates();

                Parallel.ForEach(updates, (update) =>
                {
                    try
                    {
                        if (update.UpdateType == UpdateType.Packages)
                        {
                            manager.UpdatePackages(update);
                        }
                    }
                    catch (Exception exception)
                    {
                        _logger.LogError(exception, "While trying to fetch update for {system}: {exception}", update.ManagedSystem.Name, exception.Message);
                    }
                });
            }
            catch (Exception e)
            {
                _logger.LogError("Update fetcher failed. {exception}", e.Message);
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
