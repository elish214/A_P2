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
    public class CloseMazeCommand : ICommand
    {
        /// <summary>
        /// Holds the model it's assosiated with.
        /// </summary>
        private IModel model;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="model"> the model it's assosiated with. </param>
        public CloseMazeCommand(IModel model)
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
            string name = args[0];
            MazeGame game = model.Games[name];

            //notify other player about pos change
            foreach (TcpClient c in game.Players.Keys)
            {
                Console.WriteLine("trying send close...");
                if (c != client)
                {
                    model.Controller.Send(" ", c);
                    Console.WriteLine("sent close");
                }
            }

            return new Result(Status.Close, " ");
        }
    }
}
