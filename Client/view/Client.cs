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
    public class Client
    {
        private int port;
        private IHandler handler;

        public Client() { }

        public Client(int port, IHandler handler)
        {
            this.port = port;
            this.handler = handler;
        }

        public void Communicate(int port)
        {

            IPEndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);
            TcpClient client = new TcpClient();

            client.Connect(ep);
            Console.WriteLine("You are connected");

            using (NetworkStream stream = client.GetStream())
            using (StreamReader reader = new StreamReader(stream))
            using (StreamWriter writer = new StreamWriter(stream))
            {
                writer.AutoFlush = true;
                bool running = false;

                do
                {
                    // Send data to server
                    Console.Write("COMMAND: ");
                    string command = Console.ReadLine();
                    writer.WriteLine(command);

                    do
                    {
                        Console.WriteLine(reader.ReadLine());
                    } while (reader.Peek() >= 0);

                    string first = command.Split(' ')[0];
                    if (first == "start" || first == "join")
                        Multiplayer(client);
                    //running = true;
                    else if (first == "close" || first == "generate")
                        running = false;
                } while (running);

            }
            client.Close();

        }

        private void Multiplayer(TcpClient client)
        {
            using (NetworkStream stream = client.GetStream())
            using (StreamReader reader = new StreamReader(stream))
            using (StreamWriter writer = new StreamWriter(stream))
            {
                writer.AutoFlush = true;
                bool running = true;

                var ts = new CancellationTokenSource();
                CancellationToken ct = ts.Token;
                string result;

                // Get result from server
                Task task = new Task(() =>
                {
                    do
                    {
                        result = reader.ReadLine();
                        Console.WriteLine(result);
                        if(result == " ")
                        {
                            Console.WriteLine("need to close");
                            return;
                            //close
                        }
                    } while (true);
                    //} while (reader.Peek() >= 0);
                }, ct);
                task.Start();

                do
                {
                    // Send data to server
                    Console.Write("COMMAND: ");
                    string command = Console.ReadLine();
                    writer.WriteLine(command);

                    string first = command.Split(' ')[0];
                    if (first == "close")
                        running = false;
                } while (running);

                ts.Cancel();
            }
        }



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
