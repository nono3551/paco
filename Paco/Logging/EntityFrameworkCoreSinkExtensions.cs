using System;
using Paco.Data;
using Serilog;
using Serilog.Configuration;

namespace Paco.Logging
{
    public static class EntityFrameworkCoreSinkExtensions
    {
        public static LoggerConfiguration EntityFrameworkSink(this LoggerSinkConfiguration loggerConfiguration, Func<ApplicationDbContext> dbContextProvider, IFormatProvider formatProvider = null)
        {
            return loggerConfiguration.Sink(new EntityFrameworkCoreSink(dbContextProvider, formatProvider));
        }
    }
}