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
    public class ClientModel : IModel
    {
        public Controller Controller { get; set; }

        //public Task Task { get; }

        public ClientModel(Controller controller)
        {
            Controller = controller;
        }

        public Task Task = new Task(() =>
        {
            using (NetworkStream stream = this.Controller.Client.GetStream())
            using (StreamReader reader = new StreamReader(stream))
            using (StreamWriter writer = new StreamWriter(stream))
            {
                writer.AutoFlush = true;
                //bool running = true;

                var ts = new CancellationTokenSource();
                CancellationToken ct = ts.Token;
                string result;

                // Get result from server
                Task task = new Task(() =>
                {
                    Console.WriteLine("strted");
                    do
                    {
                        result = reader.ReadLine();
                        Console.WriteLine(result);
                        if (result == " ")
                        {
                            Console.WriteLine("need to close");
                            return;
                        //close
                    }
                    } while (true);
                    //} while (reader.Peek() >= 0);
                }, ct);
            }
        });
        /*
         * handler sets controller's client to be currecnt client,
         * so that task could use this connection.
        {
        
    */
    }
}
