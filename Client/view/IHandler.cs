using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.view
{
    /// <summary>
    /// Handler interface.
    /// </summary>
    public interface IHandler
    {
        /// <summary>
        /// Handle the client.
        /// </summary>
        /// <param name="port"> the port it communicate through. </param>
        void Handle(int port);
    }
}
