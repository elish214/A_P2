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
    /// <summary>
    /// multi player model class.
    /// </summary>
    class MultiPlayerModel : Model, IMultiPlayerModel
    {
        /// <summary>
        /// private maze member.
        /// </summary>
        private Maze maze;

        /// <summary>
        /// private move member.
        /// </summary>
        private Move move;

        /// <summary>
        /// private player position member.
        /// </summary>
        private Position myPos;

        /// <summary>
        /// private opponent position member.
        /// </summary>
        private Position oppPos;

        /// <summary>
        /// Constructor.
        /// </summary>
        public MultiPlayerModel()
        {
            client.Client.Instance.Act = delegate (string result)
            {
                try
                {
                    Move move = Move.FromJSON(result);
                    Application.Current.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal,
                    (Action)(() =>
                    {
                        Move = move;
                    }
                    ));
                } catch(Exception e)
                {
                    Application.Current.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal,
                    (Action)(() =>
                    {
                        NotifyPropertyChanged("Close");
                    }
                    ));
                }
            };
        }

        /// <summary>
        /// public player position dependency object.
        /// </summary>
        public Position MyPos
        {
            get { return myPos; }
            set
            {
                myPos = value;
                NotifyPropertyChanged("MyPos");
            }
        }

        /// <summary>
        /// public opponent position dependency object.
        /// </summary>
        public Position OppPos
        {
            get { return oppPos; }
            set
            {
                oppPos = value;
                NotifyPropertyChanged("OppPos");
            }
        }

        /// <summary>
        /// public maze dependency object.
        /// </summary>
        public Maze Maze
        {
            get { return maze; }
            set
            {
                maze = value;
                NotifyPropertyChanged("Maze");
            }
        }

        /// <summary>
        /// public move dependency object.
        /// </summary>
        public Move Move
        {
            get { return move; }
            set
            {
                move = value;
                NotifyPropertyChanged("Move");
            }
        }

        /// <summary>
        /// send a move to server.
        /// </summary>
        /// <param name="move"></param>
        public void Moved(string move)
        {
            client.Client.Instance.Write($"play {move}");
        }

        /// <summary>
        /// close the game. notify other players.
        /// </summary>
        public void CloseGame()
        {
            client.Client.Instance.Write($"close {Maze.Name}");
            client.Client.Instance.Disconnect();
        }
    }
}