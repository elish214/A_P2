using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.model
{
    public class MPMenuModel : MCMenuModel, IMPMenuModel
    {
        public int ChosenGame { get; set; }
        //public string MazeName { get; set; }
        //public int MazeRows { get; set; }
        //public int MazeCols { get; set; }
    }
}
