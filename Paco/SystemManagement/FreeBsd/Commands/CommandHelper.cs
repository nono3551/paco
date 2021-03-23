using System.Linq;
using Paco.Entities.FreeBsd;
using Renci.SshNet;

namespace Paco.SystemManagement.FreeBsd.Commands
{
    public static class CommandHelper
    {
        public static FreeBsdCommandResult ExecuteCommand(this string commandText, SshClient sshClient)
        {
            var response = sshClient.CreateCommand($"{commandText} ; echo -n $?").Execute();
            var returnValue = int.Parse(response.Split("\n").Last());
            
            return new()
            {
                Command = commandText,
                Response = response,
                Return = returnValue
            };
        }
    }
}