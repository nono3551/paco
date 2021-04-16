using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Paco.Entities.Models;
using Paco.Repositories.Database;
using Paco.Services;
using Timer = System.Threading.Timer;

namespace Paco.Jobs
{
    public class Refresher : IHostedService
    {
        private readonly ILogger<Refresher> _logger;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private Timer _timer;
        private volatile bool _isTimerRunning;

        public Refresher(ILogger<Refresher> logger, IServiceScopeFactory serviceScopeFactory)
        {
            _logger = logger;
            _serviceScopeFactory = serviceScopeFactory;
        }

        public Task StartAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Timed Hosted Service running.");
            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromHours(4));
            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            if (!_isTimerRunning)
            {
                try
                {
                    _isTimerRunning = true;
                    _logger.LogInformation("SystemRefresh started.");

                    using IServiceScope workScope = _serviceScopeFactory.CreateScope();
                    SystemManagerService manager = workScope.ServiceProvider.GetRequiredService<SystemManagerService>();
                    var systems = workScope.ServiceProvider.GetRequiredService<ApplicationDbContext>().ManagedSystems
                        .ToList();

                    foreach (ManagedSystem managedSystem in systems)
                    {
                        try
                        {
                            manager.RefreshSystemInformation(managedSystem);
                        }
                        catch (Exception exception)
                        {
                            _logger.LogError(exception, "While trying to refresh {system}: {exception}",
                                managedSystem.Name, exception.Message);
                        }
                    }
                }
                catch (Exception e)
                {
                    _logger.LogError("Update fetcher failed. {exception}", e.Message);
                }
                finally
                {
                    _isTimerRunning = false;
                    _logger.LogInformation("SystemRefresh finished.");
                }
            }
        }


        public Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("SystemRefresh is stopping.");

            _timer?.Change(Timeout.Infinite, 0);
            _timer?.Dispose();

            return Task.CompletedTask;
        }
    }
}
