using Renci.SshNet;
using System.Linq;

namespace Paco.SystemManagement.Commands
{
    public class CheckVersion
    {
        public bool IsNewVersionVersionAvaliable(SshClient client)
        {
            return IsNewMajorVersionAvaliable(client) || IsNewMinorVersionAvaliable(client);
        }

        public bool IsNewMinorVersionAvaliable(SshClient client)
        {
            var running = client.CreateCommand("freebsd-version").Execute().Replace("\n", "");

            var runningVersionOnly = client.CreateCommand("freebsd-version | cut -d \"-\" -f 1").Execute().Replace("\n", "");
            var latestVersion = client.CreateCommand($"fetch -qo - http://svn.freebsd.org/base/releng/{runningVersionOnly}/sys/conf/newvers.sh | grep -E \"TYPE|REVISION|BRANCH\" | head -3").Execute();

            var currentRevision = latestVersion.Split("\n").FirstOrDefault(line => line.Contains("REVISION"))?.Split("\"")[1];
            var currentBranch = latestVersion.Split("\n").FirstOrDefault(line => line.Contains("BRANCH"))?.Split("\"")[1];

            var latest = $"{currentRevision}-{currentBranch}";

            return running != latest;
        }

        public bool IsNewMajorVersionAvaliable(SshClient client)
        {
            var runningVersionOnly = client.CreateCommand("freebsd-version | cut -d \"-\" -f 1").Execute().Replace("\n", "");
            var latestVersion = client.CreateCommand("fetch -qo - http://svn.freebsd.org/base/releng/ | grep li | grep -v '\\.\\.' | grep -v 'ALPHA' | grep -v 'BETA' | cut -d \\\" -f 2 | sed 's/\\///g' | sort -n | tail -n 1").Execute().Replace("\n", "");

            return runningVersionOnly != latestVersion;
        }
    }
}
