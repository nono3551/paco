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
        private const string PostgreSqlServerConnectionString = "PostgreSqlServer";
        private const string SqlServerConnectionString = "SqlServer";
        private const string HttpsRedirectString = "HttpsRedirect";

        public static string GetServerAddress(this IConfiguration configuration)
        {
            return configuration.GetValue<string>(ServerAddress);
        }
        
        public static int GetEmailSenderInterval(this IConfiguration configuration)
        {
            return configuration.GetValue<int>(EmailSenderInterval);
        }
        
        public static int GetSystemRefresherInterval(this IConfiguration configuration)
        {
            return configuration.GetValue<int>(SystemRefresherInterval);
        }
        
        public static int GetScheduleExecutorInterval(this IConfiguration configuration)
        {
            return configuration.GetValue<int>(ScheduleExecutorInterval);
        }

        public static bool GetHttpsRedirect(this IConfiguration configuration)
        {
            return configuration.GetValue<bool>(HttpsRedirectString);
        }

        public static SmtpOptions GetSmtpOptions(this IConfiguration configuration)
        {
            var smtpOptions = new SmtpOptions();
            configuration.GetSection(Smtp).Bind(smtpOptions);
            return smtpOptions;
        }

        public static string GetPostgreSqlServerConnectionString(this IConfiguration configuration)
        {
            return configuration.GetConnectionString(PostgreSqlServerConnectionString);
        }
        
        public static string GetSqlServerConnectionString(this IConfiguration configuration)
        {
            return configuration.GetConnectionString(SqlServerConnectionString);
        }
    }
}