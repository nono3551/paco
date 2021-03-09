using Newtonsoft.Json;

namespace Paco.Entities.FreeBsd.Uptime
{
    public class SystemUptime
    {
        [JsonProperty("uptime-information")]
        public UptimeInformation UptimeInformation { get; set; }
    }
}
