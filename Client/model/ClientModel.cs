using Client.controller;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Client.model
{
    /// <summary>
    /// Client model class.
    /// </summary>
    public class ClientModel : IModel
    {
        /// <summary>
        /// Holds the controller it's assosiated with.
        /// </summary>
        public Controller Controller { get; set; }

        /// <summary>
        /// Holds a Task.
        /// </summary>
        public Task Task { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="controller"> the controller it's assosiated with. </param>
        public ClientModel(Controller controller)
        {
            Controller = controller;
        }

        /// <summary>
        /// Initialize the task.
        /// </summary>
        /// <param name="client"> the client that the task is assosiated with. </param>
        public void InitializeTask(TcpClient client)
        {
            Task = new Task(async () =>
            {
                // when to close those?
                NetworkStream stream = client.GetStream();
                StreamReader reader = new StreamReader(stream);
                StreamWriter writer = new StreamWriter(stream);

                string result;
                writer.AutoFlush = true;

                /*
                var ts = new CancellationTokenSource();
                CancellationToken ct = ts.Token;
                */

                Console.WriteLine("started");
                do
                {
                    result = await reader.ReadLineAsync();
                    //result = reader.ReadLine();
                    Console.WriteLine(result);
                    if (result == " ")
                    {
                        Console.WriteLine("need to close");
                        break;
                        //close
                    }
                    //Console.WriteLine("still alive");
                } while (true); //} while (reader.Peek() >= 0);             
                Console.WriteLine("byebye");
            });
        }
    }
}
