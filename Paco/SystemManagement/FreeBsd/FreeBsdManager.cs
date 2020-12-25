using Paco.Data.Entities;
using Paco.SystemManagement.FreeBsd.Commands;
using System.Collections.Generic;

namespace Paco.SystemManagement.FreeBsd
{
    public class FreeBsdManager : SshManager, ISystemManager
    {
        public ManagedSystem System { get; }

        public FreeBsdManager(ManagedSystem system)
        {
            System = system;
        }

        public Dictionary<string, string> GetSystemInformation()
        {
            using var client = CreateSshClient(System);

            return new Dictionary<string, string>
            {
                { "Hostname", new Hostname().GetHostname(client) },
                { "KarnelVersion", new KarnelVersion().GetKarnel(client) },
                { "UserlandVersion", new KarnelVersion().GetUserland(client) },
                { "RunningKarnelVersion", new KarnelVersion().GetRunning(client) },
                { "pkg audit -F -r", client.CreateCommand("sudo pkg audit -F -r").Execute() },
                { "w -n", client.CreateCommand("sudo w -n --libxo=json,pretty").Execute() },
                { "pkg info", client.CreateCommand("sudo pkg info -a -d -r -s -b -B -l").Execute() },
                { "portmaster -Ld", client.CreateCommand("sudo portmaster -Ld; echo $?").Execute().Replace("\n\n", "\n").Replace("===>>>", "") },
            };
        }

        public void FetchSystemUpdates()
        {
            using var client = CreateSshClient(System);

            var result = client.CreateCommand("sudo portsnap fetch update --interactive").Execute();

            return;
        }

        public bool IsSystemUpdateAvailable()
        {
            return new CheckVersion().IsNewVersionVersionAvaliable(CreateSshClient(System));
        }
    }
}