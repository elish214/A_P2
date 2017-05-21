using MazeLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.model
{
    interface IMultiPlayerModel
    {
        event PropertyChangedEventHandler PropertyChanged;

        Maze Maze { get; set; }

        void Moved(string move);

        void CloseGame();

    }
}
