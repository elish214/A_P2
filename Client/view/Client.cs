using Client.view;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Client
{
    /// <summary>
    /// Client class.
    /// </summary>
    public class Client
    {
        /// <summary>
        /// Holds the port it communicates through.
        /// </summary>
        private int port;

        /// <summary>
        ///  Holds the handler it's assosiated with.
        /// </summary>
        private IServerHandler handler;

        /// <summary>
        /// Constructor.
        /// </summary>
        public Client() { }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="port"> the port it communicates through. </param>
        /// <param name="handler"> the handler it's assosiated with. </param>
        public Client(int port, IServerHandler handler)
        {
            this.port = port;
            this.handler = handler;
        }

        /// <summary>
        /// Activate client.
        /// </summary>
        public void Start()
        {
            Console.WriteLine("Welcome!");

            while (true)
            {
                handler.Handle(port);
            }
        }
    }
}
