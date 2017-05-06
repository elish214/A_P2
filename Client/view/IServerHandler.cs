using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client.view
{
    /// <summary>
    /// Handler interface.
    /// </summary>
    public interface IServerHandler
    {
        /// <summary>
        /// Holds it's handeled client.
        /// </summary>
        TcpClient Client { get; set; }

        /// <summary>
        /// Handle the client.
        /// </summary>
        /// <param name="IP"> the IP address of client. </param>
        /// <param name="port"> the port it communicate through. </param>
        void Handle(IPAddress IP, int port);

        string Send(string message, IPAddress IP, int port);

        /// <summary>
        /// Run task.
        /// </summary>
        void RunTask();
    }
}
