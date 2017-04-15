using Client.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client.commands
{
    public class SolveCommand : ICommand
    {
        private IModel model;

        public SolveCommand(IModel model)
        {
            this.model = model;
        }

        public string Execute(string command, ref bool running, TcpClient client)
        {
            running = false;
            return command;
        }
    }
}
