﻿using Maze;
using MazeLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public interface IModel
    {
        MazeLib.Maze GenerateMaze(string name, int rows, int cols, TcpClient client, int numOfPlayers = 1);

        MazeSolution SolveMaze(string name, int algo);

        void StartMaze(String name, int rows, int cols, TcpClient client, int numOfPlayers = 2);

        List<string> GameList();

        MazeLib.Maze Join(string name, TcpClient client);

        void Play(Direction direction, TcpClient client);

        void Close(string name, TcpClient client);
    }
}
