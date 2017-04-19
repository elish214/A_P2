using MazeComp;
using MazeLib;
using SearchAlgorithmsLib;
using Server.controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server.model
{
    /// <summary>
    /// Model interface.
    /// </summary>
    public interface IServerModel
    {
        /// <summary>
        /// Holds the controller it's assosiated with.
        /// </summary>
        ServerController Controller { get; }

        /// <summary>
        /// Holds a dictionary of games' names to it's games.
        /// </summary>
        Dictionary<string, MazeGame> MultiGames { get; }

        /// <summary>
        /// Holds a dictionary of clients to it's games.
        /// </summary>
        Dictionary<TcpClient, MazeGame> Players { get; }

        Maze Generate(String name, int rows, int cols, TcpClient client);

        MazeSolution Solve(string name, ISearcher<Position> searcher, TcpClient client);

        void Start(String name, int rows, int cols, TcpClient client);

        List<string> List();

        Maze Join(String name, TcpClient client);

        void Play(Direction direction, TcpClient client);

        void Close(String name, TcpClient client);
    }
}
