using Microsoft.AspNetCore.Identity.UI.Services;
using System.Threading.Tasks;

namespace Paco.Services
{
    public class EmailService : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            return Task.CompletedTask;
        }
    }
}
