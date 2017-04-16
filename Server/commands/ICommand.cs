using Server.controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server.commands
{
    /// <summary>
    /// Commands' interface.
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Excute command. called by controller.
        /// </summary>
        /// <param name="args"> arguments from console. </param>
        /// <param name="client"> client to handle. </param>
        /// <returns> a result to send back to client. </returns>
        Result Execute(string[] args, TcpClient client = null);
    }
}
