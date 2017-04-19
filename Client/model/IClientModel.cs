using Client.controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client.model
{
    /// <summary>
    /// Model interface.
    /// </summary>
    public interface IClientModel
    {
        /// <summary>
        /// Holds the controller it's assosiated with.
        /// </summary>
        IClientController Controller { get; }

        /// <summary>
        /// Initialize and run task through controller.
        /// </summary>
        void RunTask();
    }
}
