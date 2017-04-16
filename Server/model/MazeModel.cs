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
    /// <summary>
    /// Model class.
    /// </summary>
    public class MazeModel : IModel
    {
        /// <summary>
        /// Holds the controller it's assosiated with.
        /// </summary>
        public Controller Controller { get; }
       
        /// <summary>
        /// Holds a dictionary of games' names to it's games.
        /// </summary>
        public Dictionary<string, MazeGame> Games { get; }
        
        /// <summary>
        /// Holds a dictionary of clients to it's games.
        /// </summary>
        public Dictionary<TcpClient, MazeGame> Players { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="controller"> a controller. </param>
        public MazeModel(Controller controller)
        {
            Controller = controller;
            Games = new Dictionary<string, MazeGame>();
            Players = new Dictionary<TcpClient, MazeGame>();
        }
    }
}
