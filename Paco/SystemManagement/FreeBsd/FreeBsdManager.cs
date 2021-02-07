using Paco.Data.Entities;
using Paco.SystemManagement.FreeBsd.Commands;
using System.Collections.Generic;

namespace Paco.SystemManagement.FreeBsd
{
    public class FreeBsdManager : ISystemManager
    {
        public ManagedSystem System { get; }

        public FreeBsdManager(ManagedSystem system)
        {
            System = system;
        }

        public Dictionary<string, string> GetSystemInformation()
        {
            using var client = SshManager.CreateSshClient(System);

            return new Dictionary<string, string>
            {
                { "Hostname", new Hostname().GetHostname(client) },
                { "Logged users", Uptime.CurrentLoggedUsers(client) },
                { "Karnel version", new KarnelVersion().GetKarnel(client) },
                { "Userland version", new KarnelVersion().GetUserland(client) },
                { "Running Karnel version", new KarnelVersion().GetRunning(client) },
                { "Vulnerable packages", Audit.GetVulnerablePackages(client) },
                { "pkg info", client.CreateCommand("sudo pkg info -a -d -r -s -b -B -l").Execute() },
                { "portmaster -Ld", client.CreateCommand("sudo portmaster -Ld; echo $?").Execute().Replace("\n\n", "\n").Replace("===>>>", "") },
            };
        }

        public KeyValuePair<bool, string> NeedsInteraction()
        {
            using var client = SshManager.CreateSshClient(System);

            return Audit.NeedsInteraction(client);
        }


        public void FetchSystemUpdates()
        {
            using var client = SshManager.CreateSshClient(System);

            var result = client.CreateCommand("sudo portsnap fetch update --interactive").Execute();

            return;
        }

        public bool IsSystemUpdateAvailable()
        {
            return new CheckVersion().IsNewVersionVersionAvailable(SshManager.CreateSshClient(System));
        }
    }
}