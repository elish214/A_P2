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
    /// Play a move command class.
    /// </summary>
    public class PlayCommand : IClientCommand
    {
        /// <summary>
        /// Holds the model it's assosiated with.
        /// </summary>
        private IClientModel model;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="model"> the model it's assosiated with. </param>
        public PlayCommand(IClientModel model)
        {
            this.model = model;
        }

        /// <summary>
        /// Excute command. called by controller.
        /// </summary>
        /// <param name="command"> input command line. </param>
        /// <param name="running"> a boolean whether to stay connected. </param>
        /// <returns> a string to send back. </returns>
        public string Execute(string command, ref bool running)
        {
            running = true;

            return command;
        }
    }
}
