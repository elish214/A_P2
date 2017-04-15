using Client.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public interface IController
    {
        IModel Model { get; set; }

        //TcpClient Client { get; set; }

        string ExecuteCommand(string commandLine, ref bool running, TcpClient client);
    }
}
