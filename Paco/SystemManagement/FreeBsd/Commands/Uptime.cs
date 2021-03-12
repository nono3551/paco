using System.Linq;
using Ancestor.Extensions;
using Paco.Entities.FreeBsd.Uptime;
using Renci.SshNet;

namespace Paco.SystemManagement.FreeBsd.Commands
{
    public static class Uptime
    {
        public static string CurrentLoggedUsers(SshClient sshClient)
        {
            var loggedUsers = sshClient.CreateCommand("sudo LANG=C w -n --libxo=json,pretty").Execute().FromJson<SystemUptime>().UptimeInformation.UserTable.UserEntry.Select(user => user.User);

            return string.Join("\n", loggedUsers);
        }
    }
}
