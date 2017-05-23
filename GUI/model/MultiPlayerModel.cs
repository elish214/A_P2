using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeLib;
using MazeComp;
using System.Windows;

namespace GUI.model
{
    class MultiPlayerModel : Model, IMultiPlayerModel
    {
        private Maze maze;
        private Move move;
        private Position myPos;
        private Position oppPos;

        public MultiPlayerModel()
        {
            client.Client.Instance.Act = delegate (string result)
            {
                Move move = Move.FromJSON(result);
                Application.Current.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal,
                (Action)(() =>
                {
                    //Position pos = OppPos;
                    //
                    //switch (move.Direction)
                    //{
                    //    case Direction.Up:
                    //        pos.Row--;
                    //        break;
                    //
                    //    case Direction.Down:
                    //        pos.Row++;
                    //        break;
                    //
                    //    case Direction.Left:
                    //        pos.Col--;
                    //        break;
                    //
                    //    case Direction.Right:
                    //        pos.Col++;
                    //        break;
                    //}
                    //
                    //OppPos = pos;

                    Move = move;
                    
                }
                ));
            };
        }

        public Position MyPos
        {
            get { return myPos; }
            set
            {
                myPos = value;
                NotifyPropertyChanged("MyPos");
            }
        }

        public Position OppPos
        {
            get { return oppPos; }
            set
            {
                oppPos = value;
                NotifyPropertyChanged("OppPos");
            }
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
            client.Client.Instance.Write($"play {move}");
        }

        public void CloseGame()
        {
            client.Client.Instance.Write($"close {Maze.Name}");
        }
    }
}