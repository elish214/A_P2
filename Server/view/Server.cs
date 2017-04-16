using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server.view
{
    /// <summary>
    /// Server class.
    /// </summary>
    public class Server
    {
        /// <summary>
        /// Holds the port it communicates through.
        /// </summary>
        private int port;
        
        /// <summary>
        /// Holds the Tcp listener it listen to.
        /// </summary>
        private TcpListener listener;
        
        /// <summary>
        /// Holds the client handler it's assosiated with.
        /// </summary>
        private IClientHandler ch;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="port"> a port. </param>
        /// <param name="ch"> a client handler. </param>
        public Server(int port, IClientHandler ch)
        {
            this.port = port;
            this.ch = ch;
        }

        /// <summary>
        /// Activate server.
        /// </summary>
        public void Start()
        {
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);
            listener = new TcpListener(ep);
            listener.Start();
            Console.WriteLine("Waiting for connections...");
            Task task = new Task(() => {
                while (true)
                {
                    try
                    {
                        TcpClient client = listener.AcceptTcpClient();
                        Console.WriteLine("Got new connection");
                        ch.HandleClient(client);
                    }
                    catch (SocketException)
                    {
                        break;
                    }
                }
                Console.WriteLine("Server stopped");
            });
            task.Start();
        }

        /// <summary>
        /// Stops listener when connection ends.
        /// </summary>
        public void Stop()
        {
            listener.Stop();
        }
    }
}
