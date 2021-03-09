using Newtonsoft.Json;

namespace Paco.Entities.FreeBsd.Uptime
{
    public class UptimeInformation
    {
        [JsonProperty("time-of-day")]
        public string TimeOfDay { get; set; }

        [JsonProperty("uptime")]
        public long Uptime { get; set; }

        [JsonProperty("days")]
        public long Days { get; set; }

        [JsonProperty("hours")]
        public long Hours { get; set; }

        [JsonProperty("minutes")]
        public long Minutes { get; set; }

        [JsonProperty("seconds")]
        public long Seconds { get; set; }

        [JsonProperty("uptime-human")]
        public string UptimeHuman { get; set; }

        [JsonProperty("users")]
        public long Users { get; set; }

        [JsonProperty("load-average-1")]
        public double LoadAverage1 { get; set; }

        [JsonProperty("load-average-5")]
        public double LoadAverage5 { get; set; }

        [JsonProperty("load-average-15")]
        public double LoadAverage15 { get; set; }

        [JsonProperty("user-table")]
        public UserTable UserTable { get; set; }
    }
}