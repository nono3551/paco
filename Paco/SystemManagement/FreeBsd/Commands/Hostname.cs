﻿using Renci.SshNet;

namespace Paco.SystemManagement.FreeBsd.Commands
{
    public class Hostname
    {
        public string GetHostname(SshClient sshClient) => sshClient.CreateCommand("freebsd-version").Execute().Replace("\n", "");
    }
}
