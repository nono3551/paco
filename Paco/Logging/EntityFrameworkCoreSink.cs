using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Serilog.Core;
using Serilog.Events;
using Serilog.Formatting.Json;

using Microsoft.EntityFrameworkCore;

using Newtonsoft.Json.Linq;
using Paco.Entities.Models;
using Paco.Entities.Models.Identity;
using Paco.Repositories.Database;

namespace Paco.Logging
{
    public class EntityFrameworkCoreSink : ILogEventSink
    {
        private readonly IFormatProvider _formatProvider;
        private readonly IDbContextFactory<ApplicationDbContext> _dbContextProvider;
        private readonly JsonFormatter _jsonFormatter;
        static readonly object Lock = new();

        public EntityFrameworkCoreSink(IDbContextFactory<ApplicationDbContext> dbContextFactory, IFormatProvider formatProvider)
        {
            _formatProvider = formatProvider;
            _dbContextProvider = dbContextFactory ?? throw new ArgumentNullException(nameof(dbContextFactory));
            _jsonFormatter = new JsonFormatter(formatProvider: formatProvider);
        }

        public void Emit(LogEvent logEvent)
        {
            lock (Lock)
            {
                if (logEvent == null)
                {
                    return;
                }

                if (logEvent.Properties.GetValueOrDefault("SourceContext")?.ToString().Contains("Microsoft.EntityFrameworkCore") != true)
                {
                    try
                    {
                        _dbContextProvider.Add(ConvertLogEventToLogRecord(logEvent));
                    }
                    catch
                    {
                        // ignored
                    }
                }
                else
                {
                    Console.WriteLine(logEvent.RenderMessage());
                    Console.WriteLine(logEvent.Exception);
                }
            }
        }

        private LogRecord ConvertLogEventToLogRecord(LogEvent logEvent)
        {
            if (logEvent == null)
            {
                return null;
            }

            string json = this.ConvertLogEventToJson(logEvent);

            JObject jObject = JObject.Parse(json);
            JToken properties = jObject["Properties"];

            return new LogRecord
            {
                Exception = logEvent.Exception?.ToString(),
                Level = logEvent.Level.ToString(),
                LogEvent = json,
                Message = logEvent.RenderMessage(_formatProvider),
                MessageTemplate = logEvent.MessageTemplate?.ToString(),
                TimeStamp = logEvent.Timestamp.DateTime.ToUniversalTime(),
                EventId = (int?) properties?["EventId"]?["Id"],
                SourceContext = (string) properties?["SourceContext"],
                ActionId = (string) properties?["ActionId"],
                ActionName = (string) properties?["ActionName"],
                RequestId = (string) properties?["RequestId"],
                RequestPath = (string) properties?["RequestPath"]
            };
        }

        private string ConvertLogEventToJson(LogEvent logEvent)
        {
            if (logEvent == null)
            {
                return null;
            }

            StringBuilder sb = new StringBuilder();
            using StringWriter writer = new StringWriter(sb);
            this._jsonFormatter.Format(logEvent, writer);

            return sb.ToString();
        }
    }
}
