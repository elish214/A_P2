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
    /// <summary>
    /// Controller class
    /// </summary>
    public class ClientController : IClientController
    {
        //public TcpClient Client { get; set; }
        /// <summary>
        /// Holds the view it's assosiated with.
        /// </summary>
        public IServerHandler View { get; set; }

        /// <summary>
        ///  Holds the model it's assosiated with.
        /// </summary>
        public IClientModel Model { get; set; }

        /// <summary>
        /// Holds a dictionary of commands.
        /// </summary>
        private Dictionary<string, IClientCommand> commands;

        /// <summary>
        /// Constructor. initialize commands.
        /// </summary>
        public void BuildCommands()
        {
            commands = new Dictionary<string, IClientCommand>
            {
                {"generate", new GenerateCommand(Model) },
                {"solve", new SolveCommand(Model) },
                {"start", new StartGameCommand(Model) },
                {"list", new ListCommand(Model) },
                {"join", new JoinGameCommand(Model) },
                {"play", new PlayCommand(Model) },
                {"close", new CloseGameCommand(Model) }
            };
        }

        /// <summary>
        /// Excution command. parsing and excuting recieved commands.
        /// </summary>
        /// <param name="commandLine"> input command line. </param>
        /// <param name="running"> a boolean whether to stay connected. </param>
        /// <returns> a string to send back. </returns>
        public string ExecuteCommand(string commandLine, ref bool running)
        {
            string[] arr = commandLine.Split(' ');
            string commandKey = arr[0];

            if (!commands.ContainsKey(commandKey))
                return "Command not found";

            string[] args = arr.Skip(1).ToArray();
            IClientCommand command = commands[commandKey];

            return command.Execute(commandLine, ref running);
        }

        /// <summary>
        /// Initialize and run task through view.
        /// </summary>
        public void RunTask()
        {
            View.RunTask();
        }
    }
}
