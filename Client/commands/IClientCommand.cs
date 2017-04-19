using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    /// <summary>
    /// Commands' interface.
    /// </summary>
    public interface IClientCommand
    {
        /// <summary>
        /// Excute command. called by controller.
        /// </summary>
        /// <param name="command"> input command line. </param>
        /// <param name="running"> a boolean whether to stay connected. </param>
        /// <param name="client"> the client it's assosiated with. </param>
        /// <returns> a string to send back. </returns>
        string Execute(string command, ref bool running);
    }
}
