using Newtonsoft.Json;

namespace Paco.SystemManagement.FreeBsd.Entities.Uptime
{
    public class UserEntry
    {
        [JsonProperty("user")]
        public string User { get; set; }

        [JsonProperty("tty")]
        public string Tty { get; set; }

        [JsonProperty("from")]
        public string From { get; set; }

        [JsonProperty("login-time")]
        public string LoginTime { get; set; }

        [JsonProperty("command")]
        public string Command { get; set; }
    }
}