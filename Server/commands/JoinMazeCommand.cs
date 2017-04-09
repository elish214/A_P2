using Server.controller;
using Server.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server.commands
{
    public class JoinMazeCommand : ICommand
    {
        private IModel model;

        public JoinMazeCommand(IModel model)
        {
            this.model = model;
        }

        public Result Execute(string[] args, TcpClient client = null)
        {
            string name = args[0];

            MazeGame game = model.Games[name];

            game.Players[client] = game.Maze.InitialPos;
            model.Players[client] = game;

            /*
            while (!model.Games[name].ArePlayersReady())
            {
                Thread.Sleep(300);
            }
            */

            string json = game.Maze.ToJSON();

            model.Controller.Send(json, game.Players.Keys.ToList()[0]);

            return new Result(Status.Open, game.Maze.ToJSON());
            
        }
    }
}
