using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client.view
{
    public class Handler : IHandler
    {
        private IController Controller;

        public Handler(IController controller)
        {
            this.Controller = controller;
        }

        public void Handle(int port)
        {
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);
            TcpClient client = new TcpClient();

            client.Connect(ep);
            //Controller.Model.Client = client;
            Console.WriteLine("You are connected");

            using (NetworkStream stream = client.GetStream())
            using (StreamReader reader = new StreamReader(stream))
            using (StreamWriter writer = new StreamWriter(stream))
            {
                writer.AutoFlush = true;
                bool running = false;

                do
                {
                    Console.Write("COMMAND: ");
                    string commandLine = Console.ReadLine();

                    string result = Controller.ExecuteCommand(commandLine, ref running, client); //execute-command pattern by dict
                    writer.WriteLine(result);
                    Console.WriteLine($"answer sent, {result}, run: {running}");

                    do
                    {
                        Console.WriteLine(reader.ReadLine());
                    } while (reader.Peek() >= 0);

                } while (running);

                client.Close();
            }
        }
    }
    
}
