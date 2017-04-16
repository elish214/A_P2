using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server.view
{
    /// <summary>
    /// Client handler interface.
    /// </summary>
    public interface IClientHandler
    {
        /// <summary>
        /// Handling a client. recieve and send commands.
        /// </summary>
        /// <param name="client"> a client to communicate with. </param>
        void HandleClient(TcpClient client);

        /// <summary>
        /// Single send to a specific client.
        /// </summary>
        /// <param name="s"> a message. </param>
        /// <param name="client"> a specific client. </param>
        void SendClient(string s, TcpClient client);
    }
}
