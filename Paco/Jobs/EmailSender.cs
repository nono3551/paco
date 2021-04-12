using System;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Paco.Entities;
using Paco.Entities.Models;
using Paco.Repositories.Database;
using Paco.Services;
using Timer = System.Threading.Timer;

namespace Paco.Jobs
{
    public class EmailSender : IHostedService
    {
        private readonly ILogger<EmailSender> _logger;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private Timer _timer;
        private volatile bool _isTimerRunning;
        private IConfiguration Configuration { get; }
        
        public EmailSender(ILogger<EmailSender> logger, IServiceScopeFactory serviceScopeFactory, IConfiguration configuration)
        {
            _logger = logger;
            _serviceScopeFactory = serviceScopeFactory;
            Configuration = configuration;
        }

        public Task StartAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Timed Hosted Service running.");
            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromMinutes(1));
            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            if (!_isTimerRunning)
            {
                try
                {
                    _isTimerRunning = true;
                    _logger.LogInformation("Email sender started.");

                    using var scope = _serviceScopeFactory.CreateScope();
                    var unsentEmails = scope.ServiceProvider.GetRequiredService<IDbContextFactory<ApplicationDbContext>>().CreateDbContext().QueuedEmails.GetAllUnsentEmails();

                    _logger.LogInformation($"Email queue has {unsentEmails.Count} emails.");

                    foreach (var email in unsentEmails)
                    {
                        try
                        {
                            SendEmail(email);
                        }
                        catch (Exception exception)
                        {
                            _logger.LogError(exception, "While trying send email. {exception}", exception.Message);
                        }
                    }
                }
                catch (Exception e)
                {
                    _logger.LogError("Sending emails failed. {exception}", e.Message);
                }
                finally
                {
                    _isTimerRunning = false;
                    _logger.LogInformation("Sending emails finished.");
                }
            }
        }


        public Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Refresher is stopping.");

            _timer?.Change(Timeout.Infinite, 0);
            _timer?.Dispose();

            return Task.CompletedTask;
        }
        
        private void SendEmail(QueuedEmail queuedEmail)
        {
            try
            {
                var smtpOptions = new SmtpOptions();
                Configuration.GetSection(OptionsKeys.Smtp).Bind(smtpOptions);
            
                using SmtpClient client = new SmtpClient
                {
                    Host = smtpOptions.Host,
                    Port = smtpOptions.Port,
                    EnableSsl = true,
                    Credentials = new NetworkCredential(smtpOptions.Username, smtpOptions.Password)
                };

                using MailMessage message = new MailMessage
                {
                    From = new MailAddress(smtpOptions.SenderAddress, smtpOptions.SenderName, Encoding.UTF8),
                    Body = queuedEmail.Body,
                    IsBodyHtml = true,
                    BodyEncoding = Encoding.UTF8,
                    Subject = queuedEmail.Subject,
                    SubjectEncoding = Encoding.UTF8,
                };

                if (queuedEmail.Recipients?.Any() == true)
                {
                    foreach (var recipient in queuedEmail.Recipients)
                    {
                        message.To.Add(new MailAddress(recipient.Email));
                    }

                    client.Send(message);
                }
            
                using var scope = _serviceScopeFactory.CreateScope();
                queuedEmail.WasSent = true;
                queuedEmail.SentAt = DateTime.Now;
                scope.ServiceProvider.GetRequiredService<IDbContextFactory<ApplicationDbContext>>().Upsert(queuedEmail);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Mail could not be sent. {exception}", e.Message);
            }
        }
    }
}
