using Client.view;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Client.commands;
using Client.model;

namespace Client.controller
{
    public class Controller : IController
    {
        public TcpClient Client { get; set; }
        public IHandler View { get; set; }
        public IModel Model { get; set; } 
        private Dictionary<string, ICommand> commands;

        public void BuildCommands()
        {
            commands = new Dictionary<string, ICommand>
            {
                {"generate", new GenerateCommand(Model) },
                {"solve", new SolveCommand(Model) },
                {"start", new StartGameCommand(Model) },
                {"list", new ListCommand(Model) },
                {"join", new JoinGameCommand(Model) },
                {"play", new PlayCommand(Model) },
                {"close", null }
            };
        }

        public string ExecuteCommand(string commandLine, ref bool running)
        {
            string[] arr = commandLine.Split(' ');
            string commandKey = arr[0];

            if (!commands.ContainsKey(commandKey))
                return "Command not found";

            string[] args = arr.Skip(1).ToArray();
            ICommand command = commands[commandKey];

            return command.Execute(commandLine, ref running);
        }
    }
}
