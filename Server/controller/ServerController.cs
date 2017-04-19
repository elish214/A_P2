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
    /// <summary>
    /// Controller's class.
    /// </summary>
    public class ServerController : IServerController
    {
        /// <summary>
        /// Holds the model it's assosiated with.
        /// </summary>
        public IServerModel Model { get; set; }
        
        /// <summary>
        /// Holds the view it's assosiated with.
        /// </summary>
        public IClientHandler View { get; set; }
        
        /// <summary>
        /// Holds a dictionary of commands.
        /// </summary>
        private Dictionary<string, IServerCommand> commands;

        /// <summary>
        /// Constructor. initialize commands.
        /// </summary>
        public void BuildCommands()
        {
            commands = new Dictionary<string, IServerCommand>
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

        /// <summary>
        /// Excution command. parsing and excuting recieved commands.
        /// </summary>
        /// <param name="commandLine"> input command line. </param>
        /// <param name="client"> current client. </param>
        /// <returns> a result to send back to client. </returns>
        public Result ExecuteCommand(string commandLine, TcpClient client)
        {
            string[] arr = commandLine.Split(' ');
            string commandKey = arr[0];

            if (!commands.ContainsKey(commandKey))
                return Result.Error;

            string[] args = arr.Skip(1).ToArray();
            IServerCommand command = commands[commandKey];

            return command.Execute(args, client);
        }

        /// <summary>
        /// Sends a message to client via the view.
        /// </summary>
        /// <param name="s"> the message. </param>
        /// <param name="client"> the client. </param>
        public void Send(string s, TcpClient client)
        {
            View.SendClient(s, client);
        }
    }
}
