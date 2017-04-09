using MazeComp;
using MazeLib;
using Server.controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server.model
{
    public interface IModel
    {
        Controller Controller { get; }

        Dictionary<string, MazeGame> Games { get; }

        Dictionary<TcpClient, MazeGame> Players { get; }
    }
}
