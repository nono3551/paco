using Paco.Data.Entities;
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

        public void FetchSystemUpdates()
        {
            CreateSshClient(System).CreateCommand("portsnap fetch update >/dev/null &").Execute();
        } 

        public Dictionary<string, string> GetSystemInformation()
        {
            using var client = CreateSshClient(System);

            return new Dictionary<string, string>
            {
                { "Hostname", client.CreateCommand("hostname").Execute() },
                { "UserlandVersion", client.CreateCommand("freebsd-version -u").Execute() },
                { "KarnelVersion", client.CreateCommand("freebsd-version -k").Execute() },
                { "RunningKarnelVersion", client.CreateCommand("freebsd-version -r").Execute() },
                { "pkg audit -F -r", client.CreateCommand("pkg audit -F -r").Execute() },
                { "w -n", client.CreateCommand("w -n").Execute() },
                { "pkg info", client.CreateCommand("pkg info -a -d -r -s -b -B -l").Execute() },
                { "portmaster -Ld", CreateSshClient(System).CreateCommand("portmaster -Ld").Execute().Replace("\n\n", "\n").Replace("===>>>", "") }
            };
        }
    }
}