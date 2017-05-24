using MazeLib;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.model
{
    /// <summary>
    /// multi player menu model interface.
    /// </summary>
    public interface IMPMenuModel : IMCMenuModel
    {
        /// <summary>
        /// an event.
        /// </summary>
        event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// observable game of list.
        /// </summary>
        ObservableCollection<string> GamesList { get; set; }

        /// <summary>
        /// the chosen game.
        /// </summary>
        int ChosenGame { get; set; }

        /// <summary>
        /// a maze.
        /// </summary>
        Maze Maze { get; set; }

        /// <summary>
        /// a loading method.
        /// </summary>
        void Load();

        /// <summary>
        /// a starting method.
        /// </summary>
        void Start();

        /// <summary>
        /// a joining method.
        /// </summary>
        void Join();

        /// <summary>
        /// a closing method.
        /// </summary>
        void Close();
    }
}
