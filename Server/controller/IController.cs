using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server.controller
{
    public interface IController
    {
        Result ExecuteCommand(string commandLine, TcpClient client);

        void Send(string s, TcpClient client);
    }
}
