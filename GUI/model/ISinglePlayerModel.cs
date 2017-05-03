using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.model
{
    interface ISinglePlayerModel
    {
        //TcpClient Client { get; set; }
        string MazeName { get; set; }
        int MazeRows { get; set; }
        int MazeCols { get; set; }
    }
}
