using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.model
{
    public interface IMCMenuModel
    {
        string MazeName { get; set; }
        int MazeRows { get; set; }
        int MazeCols { get; set; }
    }
}
