using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.model
{
    public class MCMenuModel : Model, IMCMenuModel
    {
        public string MazeName { get; set; }
        public int MazeRows { get; set; }
        public int MazeCols { get; set; }

        public MCMenuModel()
        {
            MazeRows = Properties.Settings.Default.MazeRows;
            MazeCols = Properties.Settings.Default.MazeCols;
        }
    }
}
