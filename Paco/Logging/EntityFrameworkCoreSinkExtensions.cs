using System;
using Microsoft.EntityFrameworkCore;
using Paco.Repositories.Database;
using Serilog;
using Serilog.Configuration;

namespace Paco.Logging
{
    public static class EntityFrameworkCoreSinkExtensions
    {
        public static LoggerConfiguration EntityFrameworkSink(this LoggerSinkConfiguration loggerConfiguration, IDbContextFactory<ApplicationDbContext> dbContextFactory, IFormatProvider formatProvider = null)
        {
            return loggerConfiguration.Sink(new EntityFrameworkCoreSink(dbContextFactory, formatProvider));
        }
    }
}