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
    public class ClientHandler : IClientHandler
    {
        private IController controller;

        public ClientHandler(IController controller)
        {
            this.controller = controller;
        }

        public void HandleClient(TcpClient client)
        {
            new Task(() =>
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
                client.Close();
            }).Start();
        }

        public void SendClient(string s, TcpClient client)
        {
            NetworkStream stream = client.GetStream();
            StreamReader reader = new StreamReader(stream);
            StreamWriter writer = new StreamWriter(stream);

            writer.AutoFlush = true;
            writer.WriteLine(s);
            Console.WriteLine("answer sent");
        }
    }
}
