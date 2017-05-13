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
    interface ISinglePlayerModel
    {
        event PropertyChangedEventHandler PropertyChanged;

        Maze Maze { get; set; }

        MazeSolution Solution { get; set; }

        void Solve();
    }
}
