using Newtonsoft.Json;

namespace Paco.Entities.FreeBsd.Uptime
{
    public class UserTable
    {
        [JsonProperty("user-entry")]
        public UserEntry[] UserEntry { get; set; }
    }
}