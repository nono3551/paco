using System;
using Paco.Entities.Models;
using Renci.SshNet;

namespace Paco.SystemManagement.Ssh
{
    public static class SshManager
    {
        public static SshClient CreateSshClient(ManagedSystem system)
        {
            KeyboardInteractiveAuthenticationMethod keyboardAuth = new KeyboardInteractiveAuthenticationMethod(system.Login);
            PasswordAuthenticationMethod passwordAuth = new PasswordAuthenticationMethod(system.Login, system.Password);
            
            keyboardAuth.AuthenticationPrompt += (sender, args) =>
            {
                foreach (Renci.SshNet.Common.AuthenticationPrompt prompt in args.Prompts)
                {
                    if (prompt.Request.IndexOf("Password:", StringComparison.InvariantCultureIgnoreCase) != -1)
                    {
                        prompt.Response = system.Password;
                    }
                }
            };

            ConnectionInfo connectionInfo = new ConnectionInfo(system.Hostname, system.Login, passwordAuth, keyboardAuth);

            var client = new SshClient(connectionInfo);

            client.HostKeyReceived += (sender, hostKeyArgs) =>
            {
                var receivedFingerprint = new Fingerprint(hostKeyArgs.FingerPrint);
                hostKeyArgs.CanTrust = system.Fingerprint.Matches(receivedFingerprint);
            };
            client.Connect();

            return client;
        }
    }
}