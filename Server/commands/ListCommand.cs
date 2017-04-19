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
    /// List command class.
    /// </summary>
    public class ListCommand : IServerCommand
    {
        /// <summary>
        /// Holds the model it's assosiated with.
        /// </summary>
        private IServerModel model;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="model"> the model it's assosiated with. </param>
        public ListCommand(IServerModel model)
        {
            this.model = model;
        }

        /// <summary>
        /// Excute command. called by controller. prints a list of existing mazes.
        /// </summary>
        /// <param name="args"> arguments from console. </param>
        /// <param name="client"> client to handle. </param>
        /// <returns> a result to send back to client. </returns>
        public Result Execute(string[] args, TcpClient client = null)
        {
            try
            {
                if (model.List().Count == 0)
                {
                    return new Result(Status.Keep, "");
                }
                return new Result(Status.Keep, model.List().Aggregate((result, next) => $"{result}\n{next}"));
            }
            catch (Exception e)
            {
                return Result.SyntaxError;
            }
        }
    }
}
