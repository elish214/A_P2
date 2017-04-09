using MazeComp;
using MazeGeneratorLib;
using MazeLib;
using SearchAlgorithmsLib;
using SearchAlgorithmsLib.searchers;
using Server.controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server.model
{
    public class MazeModel : IModel
    {
        public Controller Controller { get; }
        public Dictionary<string, MazeGame> Games { get; }
        public Dictionary<TcpClient, MazeGame> Players { get; }

        public MazeModel(Controller controller)
        {
            Controller = controller;
            Games = new Dictionary<string, MazeGame>();
            Players = new Dictionary<TcpClient, MazeGame>();
        }
    }
}
