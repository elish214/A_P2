using MazeGeneratorLib;
using MazeLib;
using Server.controller;
using Server.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server.commands
{
    /// <summary>
    /// Generate maze command class.
    /// </summary>
    public class GenerateMazeCommand : IServerCommand
    {
        /// <summary>
        /// Holds the model it's assosiated with.
        /// </summary>
        private IServerModel model;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="model"> the model it's assosiated with. </param>
        public GenerateMazeCommand(IServerModel model)
        {
            this.model = model;
        }

        /// <summary>
        /// Excute command. called by controller. generates a maze.
        /// </summary>
        /// <param name="args"> arguments from console. </param>
        /// <param name="client"> client to handle. </param>
        /// <returns> a result to send back to client. </returns>
        public Result Execute(string[] args, TcpClient client = null)
        {
            try
            {
                string name = args[0];
                int rows = int.Parse(args[1]);
                int cols = int.Parse(args[2]);

                return new Result(Status.Close, model.Generate(name, rows, cols, client).ToJSON());
            }
            catch (Exception e)
            {
                return Result.Error;
            }
        }
    }
}
