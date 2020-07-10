using Paco.Data;
using Paco.Data.Entities;
using Renci.SshNet;
using System;

namespace Paco.Services
{
    public class SystemManagerService
    {
        private readonly ApplicationDbContext _dbContext;

        public SystemManagerService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AccessSystem(ManagedSystem system)
        {
            using var client = CreateSshClient(system);

            if (client.IsConnected)
            {
                system.LastAccessed = DateTime.UtcNow;
            }

            _dbContext.Update(system);
            _dbContext.SaveChanges();
        }

        private SshClient CreateSshClient(ManagedSystem system)
        {
            byte[] expectedFingerPrint = new byte[] {
                                            0x66, 0x31, 0xaf, 0x00, 0x54, 0xb9, 0x87, 0x31,
                                            0xff, 0x58, 0x1c, 0x31, 0xb1, 0xa2, 0x4c, 0x6b
                                       };

            var client = new SshClient(system.Hostname, system.Login, system.Password);
               
            client.HostKeyReceived += (sender, hostKeyArgs) =>
            {
                if (expectedFingerPrint.Length == hostKeyArgs.FingerPrint.Length)
                {
                    for (var i = 0; i < expectedFingerPrint.Length; i++)
                    {
                        if (expectedFingerPrint[i] != hostKeyArgs.FingerPrint[i])
                        {
                            hostKeyArgs.CanTrust = false;
                            break;
                        }
                    }
                }
                else
                {
                    hostKeyArgs.CanTrust = false;
                }

                //Todo: Fix this CanTrus set properly. Only for testing purposes
                hostKeyArgs.CanTrust = true;
            };
            client.Connect();

            return client;
        }
    }
}
