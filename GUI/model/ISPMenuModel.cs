using MazeLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.model
{
    /// <summary>
    /// single player menu model interface.
    /// </summary>
    public interface ISPMenuModel : IMCMenuModel
    {
        /// <summary>
        /// generating a maze.
        /// </summary>
        /// <returns> a maze. </returns>
        Maze Generate();
    }
}
