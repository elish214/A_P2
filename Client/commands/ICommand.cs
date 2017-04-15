using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public interface ICommand
    {
        string Execute(string command, ref bool running, TcpClient client);
    }
}
