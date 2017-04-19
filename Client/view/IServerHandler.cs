﻿using System;
using System.Collections.Generic;
using System.Linq;
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
        /// <param name="port"> the port it communicate through. </param>
        void Handle(int port);

        /// <summary>
        /// Run task.
        /// </summary>
        /// <param name="client"> the client that the task is assosiated with. </param>
        void RunTask();
    }
}