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
        /// Holds it IP address.
        /// </summary>
        private IPAddress IP;

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
        public Client(IPAddress ip, int port, IServerHandler handler)
        {
            this.port = port;
            this.handler = handler;
            this.IP = ip;
        }

        /// <summary>
        /// Activate client.
        /// </summary>
        public void Start()
        {
            Console.WriteLine("Welcome!");

            while (true)
            {
                handler.Handle(IP, port);
            }
        }

        public string Send(string message)
        {
            return handler.Send(message, IP, port);
        }
    }
}
