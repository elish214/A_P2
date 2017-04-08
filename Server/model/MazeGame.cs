using MazeComp;
using MazeLib;
using SearchAlgorithmsLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server.model
{
    public class MazeGame
    {
        public string Name { get; set; }
        public Maze Maze { get; set; }
        public Dictionary<TcpClient, Position> Players { get; set; }
        public int NumOfPlayers { get; set; }
        public MazeSolution Solution { get; set; }

        public MazeGame()
        {
            Players = new Dictionary<TcpClient, Position>();
            Solution = null;
        }

        public Boolean ArePlayersReady()
        {
            return Players.Keys.Count >= NumOfPlayers;
        }
    }
}
