using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.model
{
    class SPMenuModel : ISPMenuModel
    {
        public string MazeName { get; set; }
        public int MazeRows { get; set; }
        public int MazeCols { get; set; }
    }
}
