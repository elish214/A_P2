using MazeComp;
using MazeLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.model
{
    /// <summary>
    /// multi player model interface.
    /// </summary>
    interface IMultiPlayerModel
    {
        /// <summary>
        /// an event.
        /// </summary>
        event PropertyChangedEventHandler PropertyChanged;
        
        /// <summary>
        /// opponent position.
        /// </summary>
        Position OppPos { get; set; }

        /// <summary>
        /// a move.
        /// </summary>
        Move Move { get; }

        /// <summary>
        /// a maze.
        /// </summary>
        Maze Maze { get; set; }

        /// <summary>
        /// a moving method.
        /// </summary>
        /// <param name="move"> a move. </param>
        void Moved(string move);

        /// <summary>
        /// closing method.
        /// </summary>
        void CloseGame();
    }
}
