using Server.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server.controller
{
    /// <summary>
    /// Controllers' interface.
    /// </summary>
    public interface IController
    {
        /// <summary>
        /// Holds the model it's assosiated with.
        /// </summary>
        IModel Model { get; }

        /// <summary>
        /// Excution command. parsing and excuting recieved commands.
        /// </summary>
        /// <param name="commandLine"> input command line. </param>
        /// <param name="client"> current client. </param>
        /// <returns> a result to send back to client. </returns>
        Result ExecuteCommand(string commandLine, TcpClient client);

        /// <summary>
        /// Sends a message to client via the view.
        /// </summary>
        /// <param name="s"> the message. </param>
        /// <param name="client"> the client. </param>
        void Send(string s, TcpClient client);
    }
}
