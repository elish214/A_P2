using Client.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client.commands
{
    public class StartGameCommand : ICommand
    {
        private IModel model;

        public StartGameCommand(IModel model)
        {
            this.model = model;
        }

        public string Execute(string command, ref bool running, TcpClient client)
        {
            running = true;
            Console.WriteLine("waiting for another player...");
            model.InitializeTask(client);
            model.Task.Start();
            return command;
        }
    }
}
