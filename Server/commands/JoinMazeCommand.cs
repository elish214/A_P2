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
    /// <summary>
    /// Join maze command class.
    /// </summary>
    public class JoinMazeCommand : ICommand
    {
        /// <summary>
        /// Holds the model it's assosiated with.
        /// </summary>
        private IModel model;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="model"> the model it's assosiated with.</param>
        public JoinMazeCommand(IModel model)
        {
            this.model = model;
        }

        /// <summary>
        /// Excute command. called by controller. joins to a maze.
        /// </summary>
        /// <param name="args"> arguments from console. </param>
        /// <param name="client"> client to handle. </param>
        /// <returns> a result to send back to client. </returns>
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
