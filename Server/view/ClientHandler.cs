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
                    string commandLine = reader.ReadLine();
                    Console.WriteLine("Got command: {0} - from {1}", commandLine, client);
                    string result = controller.ExecuteCommand(commandLine, client); //execute-command pattern by dict.
                    writer.Write(result);
                }
                client.Close();
            }).Start();
            
        }
    }
}
