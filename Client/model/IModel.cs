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
    public interface IModel
    {
        /// <summary>
        /// Holds the controller it's assosiated with.
        /// </summary>
        Controller Controller { get; }

        /// <summary>
        /// Hold a task to run when needed.
        /// </summary>
        Task Task { get; }

        /// <summary>
        /// Initialize the task.
        /// </summary>
        /// <param name="client"> the client that the task is assosiated with. </param>
        void InitializeTask(TcpClient client);
    }
}
