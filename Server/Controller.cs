using Server.commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Controller : IController
    {
        private IModel model;
        private Dictionary<string, ICommand> commands;

        public Controller(IModel model)
        {
            this.model = model;

            commands = new Dictionary<string, ICommand>
            {
                { "generate", new GenerateMazeCommand(model) },
                { "solve", new SolveMazeCommand(model) },
                { "start", new StartMazeCommand(model) },
                { "list", new ListCommand(model) },
                { "join", new JoinMazeCommand(model) },
                { "play", new PlayMazeCommand(model) },
                { "close", new CloseMazeCommand(model) }
            };
        }

        public string ExecuteCommand(string commandLine, TcpClient client)
        {
            string[] arr = commandLine.Split(' ');
            string commandKey = arr[0];
            if (!commands.ContainsKey(commandKey))
                return "Command not found";
            string[] args = arr.Skip(1).ToArray();
            ICommand command = commands[commandKey];
            return command.Execute(args, client);
        }
    }
}
