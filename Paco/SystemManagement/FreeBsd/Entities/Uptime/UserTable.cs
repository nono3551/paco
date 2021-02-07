using Newtonsoft.Json;

namespace Paco.SystemManagement.FreeBsd.Entities.Uptime
{
    public class UserTable
    {
        [JsonProperty("user-entry")]
        public UserEntry[] UserEntry { get; set; }
    }
}