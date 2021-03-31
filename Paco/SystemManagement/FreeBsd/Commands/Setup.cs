using System;
using System.Security.Policy;
using Renci.SshNet;

namespace Paco.SystemManagement.FreeBsd.Commands
{
    public static class Setup
    {
        public const string Username = "paco";
        private const string Homedir = "/usr/home/paco";

        private const string SudoPrivileges = "Defaults:paco env_keep+=PAGER\n" + 
                                              "paco ALL=NOPASSWD: /usr/sbin/portsnap\n" +
                                              "paco ALL=NOPASSWD: /usr/local/sbin/portmaster\n" +
                                              "paco ALL=NOPASSWD: /usr/sbin/pkg\n" +
                                              "paco ALL=NOPASSWD: /usr/local/sbin/pkg\n" +
                                              "paco ALL=NOPASSWD: /usr/local/sbin/pkg-static\n" +
                                              "paco ALL=NOPASSWD: /bin/freebsd-version\n" +
                                              "paco ALL=NOPASSWD: /usr/sbin/freebsd-update\n" +
                                              "paco ALL=NOPASSWD: /usr/bin/w\n" +
                                              "paco ALL=NOPASSWD: /usr/bin/tee\n" +
                                              "paco ALL=NOPASSWD: /usr/bin/sed\n" +
                                              "paco ALL=NOPASSWD: /bin/mkdir\n";

        private static Func<string, string> GetRootCommandFactory(SshClient sshClient)
        {
            var sudo = "sudo -n whoami".ExecuteCommand(sshClient);
            var su = "su root -c \"whoami\"".ExecuteCommand(sshClient);
            
            if (su.Success)
            {
                return (command) => $"su root -c \"{command}\"";
            }

            if (sudo.Success)
            {
                return (command) => $"sudo -n {command}";
            }

            throw new UnauthorizedAccessException("Provided user has insufficient rights for setup. Please provide user that can use \"sudo\" or \"su\".");
        }

        public static void SetupPortCollection(SshClient sshClient, string publicKey)
        {
            var rootCommandFactory = GetRootCommandFactory(sshClient);

            var fetchUpdateResult = $"{rootCommandFactory("portsnap fetch update --interactive")}".ExecuteCommand(sshClient);
            if (!fetchUpdateResult.Success)
            {
                var fetchExtractResult = $"{rootCommandFactory("portsnap fetch extract --interactive")}".ExecuteCommand(sshClient);
                if (!fetchExtractResult.Success)
                {
                    throw new ApplicationException("Could not fetch or extract ports collection.");
                }
            }
            
            var hasPortmaster = rootCommandFactory("pkg info portmaster").ExecuteCommand(sshClient).Success;
            if (!hasPortmaster)
            {
                var portmasterInstall = rootCommandFactory("make -C /usr/ports/ports-mgmt/portmaster -DBATCH install clean").ExecuteCommand(sshClient);
                if (!portmasterInstall.Success)
                {
                    throw new ApplicationException("Could not install portmaster.");
                }
            }
            
            var hasSudo = rootCommandFactory("pkg info sudo").ExecuteCommand(sshClient).Success;
            if (!hasSudo)
            {
                var sudoInstall = rootCommandFactory("portmaster -dG security/sudo").ExecuteCommand(sshClient);
                if (!sudoInstall.Success)
                {
                    throw new ApplicationException("Could not install security/sudo.");
                }
            }

            if (!rootCommandFactory($"getent passwd {Username}").ExecuteCommand(sshClient).Success)
            {
                var nscdStop = "";
                var nscdStart = "";

                var nscdStarted = rootCommandFactory("/usr/sbin/service nscd status").ExecuteCommand(sshClient).Response.Contains("nscd is running as pid");
                
                if (nscdStarted)
                {
                    nscdStart = rootCommandFactory(" /usr/sbin/service nscd start ");
                    nscdStop = rootCommandFactory(" /usr/sbin/service nscd stop ");
                }
                
                var userCommandResult = $"{nscdStop} ; {rootCommandFactory($"pw user add -n {Username} -c {Username} -m -s /bin/sh")} ; {nscdStart}".ExecuteCommand(sshClient);
            
                if (!rootCommandFactory($"getent passwd {Username}").ExecuteCommand(sshClient).Success)
                {
                    throw new PolicyException($"Could not create user \"{Username}\". {userCommandResult.Response}");
                }
            }

            var removeSudoersResult = rootCommandFactory($"rm /usr/local/etc/sudoers.d/{Username}").ExecuteCommand(sshClient);

            foreach (var line in SudoPrivileges.Split("\n"))
            {
                var sudoersResult = rootCommandFactory($"echo {line} | tee -a /usr/local/etc/sudoers.d/{Username}").ExecuteCommand(sshClient);

                if (!sudoersResult.Success)
                {
                    throw new PolicyException($"Could not create create sudo privileges for \"{Username}\". {sudoersResult.Response}");
                }
            }
            
            var mkdirDotSshResult = rootCommandFactory($"mkdir -p '{Homedir}/.ssh'").ExecuteCommand(sshClient);
            var dotSsh = rootCommandFactory($"echo '{publicKey}' | tee '{Homedir}/.ssh/rsa_paco.pub'").ExecuteCommand(sshClient);
            var authorizedKeys = rootCommandFactory($"echo '{publicKey}' | tee '{Homedir}/.ssh/authorized_keys'").ExecuteCommand(sshClient);

            if (!dotSsh.Success || !authorizedKeys.Success)
            {
                throw new InvalidOperationException($"Could not add public key for user {Username}.\n{dotSsh}\n{authorizedKeys}");
            }
        }
    }
}