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
    /// Close maze command class.
    /// </summary>
    public class CloseMazeCommand : IServerCommand
    {
        /// <summary>
        /// Holds the model it's assosiated with.
        /// </summary>
        private IServerModel model;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="model"> the model it's assosiated with. </param>
        public CloseMazeCommand(IServerModel model)
        {
            this.model = model;
        }

        /// <summary>
        /// Excute command. called by controller. close a maze.
        /// </summary>
        /// <param name="args"> arguments from console. </param>
        /// <param name="client"> client to handle. </param>
        /// <returns> a result to send back to client. </returns>
        public Result Execute(string[] args, TcpClient client = null)
        {
            try
            {
                if (args.Count() > 1)
                {
                    throw new FormatException();
                }

                string name = args[0];

                model.Close(name, client);

                return new Result(Status.Close, " ");
            }
            catch (Exception e)
            {
                //Console.WriteLine("AAAAA");
                return Result.SyntaxError;
            }
        }
    }
}
