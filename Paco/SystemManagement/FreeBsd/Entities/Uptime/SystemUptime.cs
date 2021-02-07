using Newtonsoft.Json;

namespace Paco.SystemManagement.FreeBsd.Entities.Uptime
{
    public class SystemUptime
    {
        [JsonProperty("uptime-information")]
        public UptimeInformation UptimeInformation { get; set; }
    }
}
