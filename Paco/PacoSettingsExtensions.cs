using Microsoft.Extensions.Configuration;
using Paco.Entities;

namespace Paco
{
    public static class PacoSettingsExtensions
    {
        private const string ServerAddress = "ServerAddress";
        private const string EmailSenderInterval = "EmailSenderInterval";
        private const string SystemRefresherInterval = "SystemRefresherInterval";
        private const string ScheduleExecutorInterval = "ScheduleExecutorInterval";
        private const string Smtp = "Smtp";

        public static string GetServerAddress(this IConfiguration configuration)
        {
            return configuration.GetValue<string>(PacoSettingsExtensions.ServerAddress);
        }
        
        public static int GetEmailSenderInterval(this IConfiguration configuration)
        {
            return configuration.GetValue<int>(PacoSettingsExtensions.EmailSenderInterval);
        }
        
        public static int GetSystemRefresherInterval(this IConfiguration configuration)
        {
            return configuration.GetValue<int>(PacoSettingsExtensions.SystemRefresherInterval);
        }
        
        public static int GetScheduleExecutorInterval(this IConfiguration configuration)
        {
            return configuration.GetValue<int>(PacoSettingsExtensions.ScheduleExecutorInterval);
        }
        
        public static SmtpOptions GetSmtpOptions(this IConfiguration configuration)
        {
            var smtpOptions = new SmtpOptions();
            configuration.GetSection(PacoSettingsExtensions.Smtp).Bind(smtpOptions);
            return smtpOptions;
        }
    }
}