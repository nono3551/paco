using Paco.Data.Entities;
using Renci.SshNet;

namespace Paco.SystemManagement.Ssh
{
    public static class SshManager
    {
        public static SshClient CreateSshClient(ManagedSystem system)
        {
            var client = new SshClient(system.Hostname, system.Login, system.Password);
            var fingerprint = system.Fingerprint;

            client.HostKeyReceived += (sender, hostKeyArgs) =>
            {
                var receivedFingerprint = new Fingerprint(hostKeyArgs.FingerPrint);
                hostKeyArgs.CanTrust = fingerprint.Matches(receivedFingerprint);
            };
            client.Connect();

            return client;
        }
    }
}
