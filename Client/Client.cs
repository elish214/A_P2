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

                // Get result from server
                Task task = new Task(() =>
                {
                    do
                    {
                        if (reader.Peek() >= 0)
                            Console.WriteLine(reader.ReadLine());
                    } while (true);
                    //} while (reader.Peek() >= 0);
                });
                //task.Start();

                do
                {
                    // Send data to server
                    Console.Write("COMMAND: ");
                    string command = Console.ReadLine();
                    writer.WriteLine(command);

                    string first = command.Split(' ')[0];
                    if (first == "start" || first == "join")
                        running = true;
                    else if (first == "close" || first == "generate")
                        running = false;

                    do
                    {
                        Console.WriteLine(reader.ReadLine());
                    } while (reader.Peek() >= 0);
                } while (running);

            }

            client.Close();




            /*
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);
            TcpClient client = new TcpClient();

            client.Connect(ep);
            Console.WriteLine("You are connected");

            using (NetworkStream stream = client.GetStream())
            using (StreamReader reader = new StreamReader(stream))
            using (StreamWriter writer = new StreamWriter(stream))
            {
                // listen to server

                Task task = new Task(() =>
                {
                    while (true)
                    {
                        string result = reader.ReadLine();
                        if (result != null)
                            Console.Write("Result = {0}\n- ", result);
                    }
                });
                //task.Start();

                // send commands to server
                //while (true)

                Console.Write("- ");
                writer.Flush();
                writer.Write(Console.ReadLine() + "\n");
                task.Start();

                writer.Flush();

                while (true) ;
            }
            client.Close();
            */

        }
    }
}
