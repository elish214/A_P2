using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeLib;

namespace GUI.model
{
    class MultiPlayerModel : Model, IMultiPlayerModel
    {
        private Maze maze;

        public Maze Maze
        {
            get { return maze; }
            set
            {
                maze = value;
                NotifyPropertyChanged("Maze");
            }
        }

        public void Moved(string move)
        {
            client.Client.Instance.Write($"move {move}");
        }

        public void CloseGame()
        {
            client.Client.Instance.Write($"close {Maze.Name}");
        }
    }
}