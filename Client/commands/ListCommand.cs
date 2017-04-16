﻿using Client.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client.commands
{
    /// <summary>
    /// List command class.
    /// </summary>
    public class ListCommand : ICommand
    {
        /// <summary>
        /// Holds the model it's assosiated with.
        /// </summary>
        private IModel model;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="model"> the model it's assosiated with. </param>
        public ListCommand(IModel model)
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
            return command;
        }
    }
}
