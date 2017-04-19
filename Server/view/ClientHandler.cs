using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Sockets;
using Server.controller;

namespace Server.view
{
    /// <summary>
    /// Client handler class.
    /// </summary>
    public class ClientHandler : IClientHandler
    {
        /// <summary>
        /// Holds the controller it's assosiated with.
        /// </summary>
        private IServerController controller;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="controller"> a controller. </param>
        public ClientHandler(IServerController controller)
        {
            this.controller = controller;
        }

        /// <summary>
        /// Handling a client. recieve and send commands.
        /// </summary>
        /// <param name="client"> a client to communicate with. </param>
        public void HandleClient(TcpClient client)
        {
            new Task(() =>
            {
                try
                {
                    using (NetworkStream stream = client.GetStream())
                    using (StreamReader reader = new StreamReader(stream))
                    using (StreamWriter writer = new StreamWriter(stream))
                    {
                        writer.AutoFlush = true;
                        Status status = Status.Close;

                        do
                        {
                            Console.WriteLine("waiting for a command....");
                            string commandLine = reader.ReadLine();
                            Console.WriteLine("Got command: [{0}] - from {1}", commandLine, client);
                            Result result = controller.ExecuteCommand(commandLine, client); //execute-command pattern by dict.
                            if (result.Status != Status.Keep)
                                status = result.Status;

                            if (result.Response != "")
                            {
                                writer.WriteLine(result.Response);
                                Console.WriteLine("answer sent, [{0}]\n {1}", status, result.Response);
                            }
                        } while (status != Status.Close);
                    }
                }
                catch (Exception e)
                {
                    e.GetBaseException();
                    Console.WriteLine("other client closed the game");
                }
                finally
                {
                    client.Close();
                }
            }).Start();
        }

        /// <summary>
        /// Single send to a specific client.
        /// </summary>
        /// <param name="s"> a message. </param>
        /// <param name="client"> a specific client. </param>
        public void SendClient(string s, TcpClient client)
        {
            NetworkStream stream = client.GetStream();
            StreamWriter writer = new StreamWriter(stream)
            {
                AutoFlush = true
            };

            writer.WriteLine(s);
            Console.WriteLine("answer sent");
        }
    }
}
