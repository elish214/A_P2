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
    interface IMultiPlayerModel
    {
        event PropertyChangedEventHandler PropertyChanged;
        
        Position OppPos { get; set; }

        Move Move { get; }

        Maze Maze { get; set; }

        void Moved(string move);

        void CloseGame();

    }
}
