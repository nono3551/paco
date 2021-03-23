using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Paco.Entities.Models;
using Renci.SshNet;

namespace Paco.SystemManagement.Ssh
{
    public static class SshManager
    {
        public static SshClient CreateSshClient(ManagedSystem system)
        {
            var methods = new List<AuthenticationMethod>();

            if (system.Password != null)
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
                
                methods.Add(keyboardAuth);
                methods.Add(passwordAuth);
            }
            else
            {
                PrivateKeyAuthenticationMethod pkMethod = new PrivateKeyAuthenticationMethod(system.Login, new PrivateKeyFile(new MemoryStream(Encoding.UTF8.GetBytes(system.SshPrivateKey ?? string.Empty))));
                methods.Add(pkMethod);
            }

            ConnectionInfo connectionInfo = new ConnectionInfo(system.Hostname, system.Login, methods.ToArray());

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