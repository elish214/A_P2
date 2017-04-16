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
    /// <summary>
    /// Start maze command class.
    /// </summary>
    public class StartMazeCommand : ICommand
    {
        /// <summary>
        /// Holds the model it's assosiated with.
        /// </summary>
        private IModel model;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="model"> the model it's assosiated with. </param>
        public StartMazeCommand(IModel model)
        {
            this.model = model;
        }

        /// <summary>
        /// Excute command. called by controller. starts a maze.
        /// </summary>
        /// <param name="args"> arguments from console. </param>
        /// <param name="client"> a client to handle. </param>
        /// <returns> a result to send back to client. </returns>
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
