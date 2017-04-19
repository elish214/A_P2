using MazeComp;
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
    /// Play maze command class.
    /// </summary>
    class PlayMazeCommand : IServerCommand
    {
        /// <summary>
        /// Holds the model it's assosiated with.
        /// </summary>
        private IServerModel model;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="model"> the model it's assosiated with. </param>
        public PlayMazeCommand(IServerModel model)
        {
            this.model = model;
        }

        /// <summary>
        /// Excute command. called by controller. play a move in maze.
        /// </summary>
        /// <param name="args"> arguments from console. </param>
        /// <param name="client"> client to handle. </param>
        /// <returns> a result to send back to client. </returns>
        public Result Execute(string[] args, TcpClient client = null)
        {
            try
            {
                if(!Enum.TryParse(args[0].First().ToString().ToUpper() + args[0].Substring(1), out Direction direction))
                {
                    throw new FormatException();
                }

                model.Play(direction, client);

                return new Result(Status.Keep, "");
            }
            catch (Exception e)
            {
                return Result.SyntaxError;
            }
        }
    }
}
