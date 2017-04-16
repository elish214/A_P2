using MazeComp;
using MazeLib;
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
    public interface IModel
    {
        /// <summary>
        /// Holds the controller it's assosiated with.
        /// </summary>
        Controller Controller { get; }

        /// <summary>
        /// Holds a dictionary of games' names to it's games.
        /// </summary>
        Dictionary<string, MazeGame> Games { get; }

        /// <summary>
        /// Holds a dictionary of clients to it's games.
        /// </summary>
        Dictionary<TcpClient, MazeGame> Players { get; }
    }
}
