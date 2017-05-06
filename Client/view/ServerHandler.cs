using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Configuration;

namespace Client.view
{
    /// <summary>
    /// Handler class.
    /// </summary>
    public class ServerHandler : IServerHandler
    {
        /// <summary>
        /// Holds a string for commands.
        /// </summary>
        private string commandLine;

        /// <summary>
        /// Holds a string for result.
        /// </summary>
        private string result;

        /// <summary>
        /// Holds a boolean to know whether to run or not.
        /// </summary>
        private bool running;

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
            result = "";
            running = false;
        }

        /// <summary>
        /// Execute current command.
        /// </summary>
        private void ExecuteCommand()
        {
            if (!result.Equals("Command not found") && !result.Equals("Connection failed"))
            {
                Controller.ExecuteCommand(commandLine, ref running); //execute-command pattern by dict
                //Console.WriteLine("EXECUTE COMMAND");
            }
        }

        /// <summary>
        /// Handle the client.
        /// </summary>
        /// <param name="IP"> the IP address of client. </param>
        /// <param name="port"> the port it communicate through. </param>
        public void Handle(IPAddress IP, int port)
        {
            IPEndPoint ep = new IPEndPoint(IP, port);
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

                    do
                    {
                        Console.Write("COMMAND: ");
                        if (commandLine == "")
                        {
                            commandLine = Console.ReadLine();
                        }

                        writer.WriteLine(commandLine);
                        //Console.WriteLine($"answer sent, {commandLine}, run: {running}");

                        if (!running)
                        {
                            do
                            {
                                result = reader.ReadLine();
                                Console.WriteLine(result);
                            } while (reader.Peek() >= 0);

                            ExecuteCommand();
                            //Console.WriteLine("EXECUTE MAIN THREAD");
                        }

                        commandLine = "";
                    } while (running);
                }
            }
            catch (Exception e)
            {
                //Console.WriteLine("THREAD EXCEPTION");
            }
            finally
            {
                //Console.WriteLine("not running");
                Client.Close();
            }
        }

        public string Send(string message, IPAddress IP, int port)
        {
            IPEndPoint ep = new IPEndPoint(IP, port);
            Client = new TcpClient();
            string answer = "";

            Client.Connect(ep);
            Console.WriteLine("You are connected");

            try
            {
                using (NetworkStream stream = Client.GetStream())
                using (StreamReader reader = new StreamReader(stream))
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.AutoFlush = true;

                    do
                    {
                        Console.Write("COMMAND: " + message);
                        if (commandLine == "")
                        {
                            commandLine = message + "\n";
                        }

                        writer.WriteLine(commandLine);
                        //Console.WriteLine($"answer sent, {commandLine}, run: {running}");

                        if (!running)
                        {
                            do
                            {
                                result = reader.ReadLine();
                                answer += result;
                                Console.WriteLine(result);
                            } while (reader.Peek() >= 0);

                            ExecuteCommand();
                            //Console.WriteLine("EXECUTE MAIN THREAD");
                        }

                        commandLine = "";
                    } while (running);
                }
            }
            catch (Exception e)
            {
                //Console.WriteLine("THREAD EXCEPTION");
            }
            finally
            {
                //Console.WriteLine("not running");
                Client.Close();
            }

            return answer;
        }

        /// <summary>
        /// Run task.
        /// </summary>
        public void RunTask()
        {
            Task = new Task(() =>
            {

                NetworkStream stream = Client.GetStream();
                StreamReader reader = new StreamReader(stream);
                StreamWriter writer = new StreamWriter(stream)
                {
                    AutoFlush = true
                };

                Console.WriteLine("started");
                try
                {
                    do
                    {
                        do
                        {
                            result = reader.ReadLine();
                            //result = reader.ReadLine();
                            Console.WriteLine(result);
                            if (result == " ")
                            {
                                //Console.WriteLine("need to close");
                                break;
                            }
                            if (result == "Connection failed")
                            {
                                //Console.WriteLine("Connection failed");
                                break;
                            }
                        } while (reader.Peek() > 0);

                        ExecuteCommand();
                        //Console.WriteLine("EXECUTE TASK");

                    } while (true);
                }
                catch (Exception e)
                {
                    //Console.WriteLine("TASK EXCEPTION");
                }
                finally
                {
                    //Console.WriteLine("byebye");
                    running = false;
                }
            });
            Task.Start();
        }
    }
}
