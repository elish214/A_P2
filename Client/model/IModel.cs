using Client.controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client.model
{
    public interface IModel
    { 
        TcpClient Client { get; set; } 

        Controller Controller { get; }

        Task Task { get; }

        void InitializeTask(TcpClient client);
    }
}
