﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Client.view
{
    /// <summary>
    /// Handler class.
    /// </summary>
    public class ServerHandler : IServerHandler
    {
        /// <summary>
        /// A string.
        /// </summary>
        private string commandLine;

        /// <summary>
        /// Holds a Task.
        /// </summary>
        public Task Task { get; set; }

        /// <summary>
        /// Holds it's handeled client.
        /// </summary>
        public TcpClient Client { get; set; }

        /// <summary>
        /// Holds the controller it's assosiated with.
        /// </summary>
        private IClientController Controller;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="controller"> a controller. </param>
        public ServerHandler(IClientController controller)
        {
            Controller = controller;
            commandLine = "";
        }


        /// <summary>
        /// Handle the client.
        /// </summary>
        /// <param name="port"> the port it communicate through. </param>
        public void Handle(int port)
        {
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);
            Client = new TcpClient();

            Client.Connect(ep);
            Console.WriteLine("You are connected");

            try
            {
                using (NetworkStream stream = Client.GetStream())
                using (StreamReader reader = new StreamReader(stream))
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.AutoFlush = true;
                    bool running = false;

                    do
                    {
                        Console.Write("COMMAND: ");
                        if (commandLine == "")
                            commandLine = Console.ReadLine();

                        string result = Controller.ExecuteCommand(commandLine, ref running); //execute-command pattern by dict
                        writer.WriteLine(result);
                        Console.WriteLine($"answer sent, {result}, run: {running}");

                        if (!running)
                        {
                            do
                            {
                                Console.WriteLine(reader.ReadLine());
                            } while (reader.Peek() >= 0);
                        }
                        commandLine = "";
                    } while (running);
                }
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            finally
            {
                Console.WriteLine("not running");
                Client.Close();
            }
        }

        /// <summary>
        /// Run task.
        /// </summary>
        /// <param name="client"> the client that the task is assosiated with. </param>
        public void RunTask()
        {
            Task = new Task(() =>
            {

                NetworkStream stream = Client.GetStream();
                StreamReader reader = new StreamReader(stream);
                StreamWriter writer = new StreamWriter(stream);

                string result;
                writer.AutoFlush = true;

                Console.WriteLine("started");
                try
                {
                    do
                    {
                        result = reader.ReadLine();
                        //result = reader.ReadLine();
                        Console.WriteLine(result);
                        if (result == " ")
                        {
                            Console.WriteLine("need to close");
                            break;
                        }
                    } while (true);
                }
                finally
                {
                    Console.WriteLine("byebye");
                }
            });
            Task.Start();
        }
    }
}