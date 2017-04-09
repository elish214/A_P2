using Server.commands;
using Server.model;
using Server.view;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server.controller
{
    public class Controller : IController
    {
        public IModel Model { get; set; }
        public IClientHandler View { get; set; }
        private Dictionary<string, ICommand> commands;

        public void BuildCommands()
        {
            commands = new Dictionary<string, ICommand>
                {
                    { "generate", new GenerateMazeCommand(Model) },
                    { "solve", new SolveMazeCommand(Model) },
                    { "start", new StartMazeCommand(Model) },
                    { "list", new ListCommand(Model) },
                    { "join", new JoinMazeCommand(Model) },
                    { "play", new PlayMazeCommand(Model) },
                    { "close", new CloseMazeCommand(Model) }
                };
        }

        public Result ExecuteCommand(string commandLine, TcpClient client)
        {
            string[] arr = commandLine.Split(' ');
            string commandKey = arr[0];

            if (!commands.ContainsKey(commandKey))
                return new Result(Status.Keep, "Command not found");

            string[] args = arr.Skip(1).ToArray();
            ICommand command = commands[commandKey];

            return command.Execute(args, client);
        }

        public void Send(string s, TcpClient client)
        {
            View.SendClient(s, client);
        }
    }
}
