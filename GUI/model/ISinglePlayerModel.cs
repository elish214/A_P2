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
    /// single player interface.
    /// </summary>
    interface ISinglePlayerModel
    {
        /// <summary>
        /// a event.
        /// </summary>
        event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// a maze.
        /// </summary>
        Maze Maze { get; set; }

        /// <summary>
        /// a maze solution.
        /// </summary>
        MazeSolution Solution { get; set; }

        /// <summary>
        /// a solving method.
        /// </summary>
        void Solve();
    }
}
