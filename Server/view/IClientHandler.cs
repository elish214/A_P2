using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server.view
{
    public interface IClientHandler
    {
        void HandleClient(TcpClient client);

        void SendClient(string s, TcpClient client);
    }
}
