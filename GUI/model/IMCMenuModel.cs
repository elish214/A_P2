using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.model
{
    /// <summary>
    /// maze control menu model interface.
    /// </summary>
    public interface IMCMenuModel
    {
        /// <summary>
        /// maze name.
        /// </summary>
        string MazeName { get; set; }

        /// <summary>
        /// maze rows.
        /// </summary>
        int MazeRows { get; set; }

        /// <summary>
        /// maze collumns.
        /// </summary>
        int MazeCols { get; set; }
    }
}
