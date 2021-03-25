using System;
using System.IO;
using System.Security.Authentication;
using System.Text;
using Paco.Entities.Models;
using Renci.SshNet;

namespace Paco.SystemManagement.Ssh
{
    public static class SshManager
    {
        public static SshClient CreateSshClient(ManagedSystem system)
        {
            ConnectionInfo connectionInfo;

            if (!string.IsNullOrEmpty(system.OneTimePassword) && !string.IsNullOrEmpty(system.OneTimeLogin))
            {
                KeyboardInteractiveAuthenticationMethod keyboardAuth = new KeyboardInteractiveAuthenticationMethod(system.OneTimeLogin);
                PasswordAuthenticationMethod passwordAuth = new PasswordAuthenticationMethod(system.OneTimeLogin, system.OneTimePassword);

                keyboardAuth.AuthenticationPrompt += (sender, args) =>
                {
                    foreach (Renci.SshNet.Common.AuthenticationPrompt prompt in args.Prompts)
                    {
                        if (prompt.Request.IndexOf("Password:", StringComparison.InvariantCultureIgnoreCase) != -1)
                        {
                            prompt.Response = system.OneTimePassword;
                        }
                    }
                };
                
                connectionInfo = new ConnectionInfo(system.Hostname, system.OneTimeLogin, keyboardAuth, passwordAuth);
            }
            else if (!string.IsNullOrEmpty(system.SshPrivateKey) && !string.IsNullOrEmpty(system.SshLogin))
            {
                PrivateKeyAuthenticationMethod pkMethod = new PrivateKeyAuthenticationMethod(system.SshLogin, new PrivateKeyFile(new MemoryStream(Encoding.UTF8.GetBytes(system.SshPrivateKey ?? string.Empty))));
                connectionInfo = new ConnectionInfo(system.Hostname, system.SshLogin, pkMethod);
            }
            else
            {
                throw new AuthenticationException($"Could not create authentication for system {system.Name}.");
            }


            var client = new SshClient(connectionInfo);

            client.HostKeyReceived += (sender, hostKeyArgs) =>
            {
                var receivedFingerprint = new Fingerprint(hostKeyArgs.FingerPrint);
                hostKeyArgs.CanTrust = system.Fingerprint.Matches(receivedFingerprint);
                
                if (string.IsNullOrEmpty(system.SystemFingerprint))
                {
                    system.SystemFingerprint = receivedFingerprint.Text;
                    throw new AuthenticationException("System fingerprint was filled automatically.");
                }
            };
            client.Connect();

            return client;
        }
    }
}