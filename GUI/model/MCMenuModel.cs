using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.model
{
    /// <summary>
    /// maze control menu model class.
    /// </summary>
    public class MCMenuModel : Model, IMCMenuModel
    {
        /// <summary>
        /// a maze name.
        /// </summary>
        public string MazeName { get; set; }

        /// <summary>
        /// maze rows.
        /// </summary>
        public int MazeRows { get; set; }

        /// <summary>
        /// maze collumns.
        /// </summary>
        public int MazeCols { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        public MCMenuModel()
        {
            MazeRows = Properties.Settings.Default.MazeRows;
            MazeCols = Properties.Settings.Default.MazeCols;
        }
    }
}
