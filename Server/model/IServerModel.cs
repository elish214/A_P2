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
        /// Generates single player maze game.
        /// </summary>
        /// <param name="name">maze name</param>
        /// <param name="rows">maze rows</param>
        /// <param name="cols">maze cols</param>
        /// <param name="client">maze player</param>
        /// <returns>new maze</returns>
        Maze Generate(String name, int rows, int cols, TcpClient client);

        /// <summary>
        /// Solves maze.
        /// </summary>
        /// <param name="name">maze name</param>
        /// <param name="searcher">searcher to use</param>
        /// <param name="client">maze player</param>
        /// <returns>solution</returns>
        MazeSolution Solve(string name, ISearcher<Position> searcher, TcpClient client);

        /// <summary>
        /// Starts multiplayer maze game.
        /// </summary>
        /// <param name="name">maze name</param>
        /// <param name="rows">maze rows</param>
        /// <param name="cols">maze cols</param>
        /// <param name="client">maze player</param>
        void Start(String name, int rows, int cols, TcpClient client);

        /// <summary>
        /// Gets list of pending games.
        /// </summary>
        /// <returns>list of pending games</returns>
        List<string> List();

        /// <summary>
        /// Joins a pending game.
        /// </summary>
        /// <param name="name">game name</param>
        /// <param name="client">player</param>
        /// <returns>new maze</returns>
        Maze Join(String name, TcpClient client);

        /// <summary>
        /// Play a single move.
        /// </summary>
        /// <param name="direction">move dircection</param>
        /// <param name="client">player played</param>
        void Play(Direction direction, TcpClient client);

        /// <summary>
        /// Closes multiplayer game.
        /// </summary>
        /// <param name="name">game name</param>
        /// <param name="client">player</param>
        void Close(String name, TcpClient client);
    }
}
