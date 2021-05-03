using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Paco.Entities.Models.Identity;
using Paco.Repositories.Database;
using Paco.Services;

namespace Paco.Jobs
{
    public class Initializer : IHostedService
    {
        private readonly ILogger<Initializer> _logger;
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public Initializer(ILogger<Initializer> logger, IServiceScopeFactory serviceScopeFactory)
        {
            _logger = logger;
            _serviceScopeFactory = serviceScopeFactory;
        }

        public Task StartAsync(CancellationToken stoppingToken)
        {
            return Task.Run(async () =>
            {
                using var scope = _serviceScopeFactory.CreateScope();
                await using var dbContext = scope.ServiceProvider.GetService<IDbContextFactory<ApplicationDbContext>>()?.CreateDbContext();
                var inviteService = scope.ServiceProvider.GetService<UserInviteService>();
                var rolesService = scope.ServiceProvider.GetService<RoleManager<Role>>();
                var userManager = scope.ServiceProvider.GetService<UserManager<User>>();

                Role administratorRole = null;
                
                if (rolesService != null)
                {
                    administratorRole = await rolesService.FindByNameAsync("Administrator");

                    if (administratorRole == null)
                    {
                        administratorRole = new Role {Name = "Administrator"};
                        await rolesService.CreateAsync(administratorRole);
                    }
                }

                if (dbContext == null)
                {
                    _logger.LogError("Initializer - Database context not registered properly.");
                }
                else if (inviteService == null)
                {
                    _logger.LogError("No service for inviting users was found. Register this service.");
                }
                else if (rolesService == null)
                {
                    _logger.LogError("No service for managing roles was found. Register this service.");
                }
                else if (userManager == null)
                {
                    _logger.LogError("No service for managing users was found. Register this service.");
                }
                else if (dbContext.Users.Any())
                {
                    _logger.LogInformation("Initializer - User already exists.");
                }
                else
                {
                    await Task.Delay(2000, stoppingToken);

                    Console.Write("No user was found. Create new user. Enter email:");
                    
                    var email = Console.ReadLine();

                    var user = await inviteService.InviteNewAdministrator(email);

                    await userManager.AddToRoleAsync(user, administratorRole?.Name);
                }
            }, stoppingToken);
        }

        public Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Initializer is stopping.");
            
            return Task.CompletedTask;
        }
    }
}
