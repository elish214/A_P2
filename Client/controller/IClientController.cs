using Client.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    /// <summary>
    /// Controller interface.
    /// </summary>
    public interface IClientController
    {
        /// <summary>
        /// Holds the controller it's assosiated with.
        /// </summary>
        IClientModel Model { get; set; }

        /// <summary>
        /// Excution command. parsing and excuting recieved commands.
        /// </summary>
        /// <param name="commandLine"> input command line. </param>
        /// <param name="running"> a boolean whether to stay connected. </param>
        /// <returns> a string to send back. </returns>
        string ExecuteCommand(string commandLine, ref bool running);

        /// <summary>
        /// Initialize and run task through view.
        /// </summary>
        void RunTask();
    } 
}
