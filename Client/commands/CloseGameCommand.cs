using Client.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Client.commands
{
    /// <summary>
    /// Close game command class.
    /// </summary>
    public class CloseGameCommand : ICommand
    {
        /// <summary>
        /// Holds the model it's assosiated with.
        /// </summary>
        private IModel model;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="model"> the model it's assosiated with. </param>
        public CloseGameCommand(IModel model)
        {
            this.model = model;
        }

        /// <summary>
        /// Excute command. called by controller.
        /// </summary>
        /// <param name="command"> input command line. </param>
        /// <param name="running"> a boolean whether to stay connected. </param>
        /// <param name="client"> the client it's assosiated with. </param>
        /// <returns> a string to send back. </returns>
        public string Execute(string command, ref bool running, TcpClient client)
        {
            running = false;

            //model.Task.Wait(); // wait for to the task to get an empty JSON and break the loop.

            return command;
        }
    }
}
