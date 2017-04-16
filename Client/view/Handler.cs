﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client.view
{
    /// <summary>
    /// Handler class.
    /// </summary>
    public class Handler : IHandler
    {
        /// <summary>
        /// Holds the controller it's assosiated with.
        /// </summary>
        private IController Controller;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="controller"> a controller. </param>
        public Handler(IController controller)
        {
            this.Controller = controller;
        }

        /// <summary>
        /// Handle the client.
        /// </summary>
        /// <param name="port"> the port it communicate through. </param>
        public void Handle(int port)
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
