using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using MazeLib;
using Server.model;
using Server.controller;
using MazeGeneratorLib;
using System.Threading;

namespace Server.commands
{
    public class StartMazeCommand : ICommand
    {
        private IModel model;

        public StartMazeCommand(IModel model)
        {
            this.model = model;
        }

        public Result Execute(string[] args, TcpClient client = null)
        {
            string name = args[0];
            int rows = int.Parse(args[1]);
            int cols = int.Parse(args[2]);

            MazeGame game = new MazeGame()
            {
                Name = name,
                Maze = new DFSMazeGenerator().Generate(rows, cols),
                NumOfPlayers = 2
            };

            game.Maze.Name = name;
            game.Players[client] = game.Maze.InitialPos;
            model.Players[client] = game;
            model.Games[name] = game;

            /*
            while (!model.Games[name].ArePlayersReady())
            {
                Thread.Sleep(300);
            }
            
            return new Result(Status.Open, game.Maze.ToJSON());
            */

            return new Result(Status.Open, "");

        }
    }
}
