using Paco.Data.Entities;
using Paco.SystemManagement.Commands;
using System.Collections.Generic;

namespace Paco.SystemManagement
{
    public class FreeBsdManager : SshManager, IDistributionManager
    {
        public ManagedSystem System { get; }

        public FreeBsdManager(ManagedSystem system)
        {
            System = system;
        }

        public Dictionary<string, string> GetSystemInformation()
        {
            using var client = CreateSshClient(System);

            var asd = new CheckVersion().IsNewVersionVersionAvaliable(client);

            return new Dictionary<string, string>
            {
                { "Hostname", client.CreateCommand("hostname").Execute() },
                { "KarnelVersion", client.CreateCommand("sudo freebsd-version -k").Execute() },
                { "UserlandVersion", client.CreateCommand("sudo freebsd-version -u").Execute() },
                { "RunningKarnelVersion", client.CreateCommand("sudo freebsd-version -r").Execute() },
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
    }
}