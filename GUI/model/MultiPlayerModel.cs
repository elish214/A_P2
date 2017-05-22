using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeLib;
using MazeComp;

namespace GUI.model
{
    class MultiPlayerModel : Model, IMultiPlayerModel
    {
        private Maze maze;
        private Move move;

        public MultiPlayerModel()
        {
            client.Client.Instance.Act = delegate (string result)
            {
                //initiallize that would listen to moves from server?...
            };
        }

        public Maze Maze
        {
            get { return maze; }
            set
            {
                maze = value;
                NotifyPropertyChanged("Maze");
            }
        }

        public Move Move
        {
            get { return move; }
            set
            {
                move = value;
                NotifyPropertyChanged("Move");
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