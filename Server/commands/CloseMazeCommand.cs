using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server.commands
{
    public class CloseMazeCommand : ICommand
    {
        private IModel model;

        public CloseMazeCommand(IModel model)
        {
            this.model = model;
        }

        public string Execute(string[] args, TcpClient client = null)
        {
            string name = args[0];
            model.Close(name, client);
            return " ";
        }
    }
}
