using GUI.windows;
using MazeComp;
using MazeLib;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace GUI.model
{


    public class MPMenuModel : MCMenuModel, IMPMenuModel
    {
        private Maze maze;
        private ObservableCollection<string> gamesList = new ObservableCollection<string>();

        public Maze Maze
        {
            get { return maze; }
            set
            {
                maze = value;
                NotifyPropertyChanged("Maze");
            }
        }

        public ObservableCollection<string> GamesList
        {
            get { return gamesList; }
            set
            {
                gamesList = value;
                NotifyPropertyChanged("GamesList");
            }
        }

        public int ChosenGame { get; set; }

        public void Load()
        {
            string list = client.Client.Instance.WriteRead("list"); // happen at begin.
            // will update COMBOBOX.
            List<string> games = list.Split('\n').ToList();
            games.RemoveAt(games.Count - 1);

            foreach (string g in games)
            {
                GamesList.Add(g);
            }
            NotifyPropertyChanged("GamesList");
        }

        public Boolean Start()
        {
            client.Client.Instance.Act = delegate (string result)
            {
                Maze = Maze.FromJSON(result);
                Application.Current.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal,
                (Action)(() =>
                {
                    new MultiPlayerWindow(Maze).Show();
                }
                ));

                client.Client.Instance.Act = delegate (string r)
                {
                    Move move = Move.FromJSON(r);
                    Application.Current.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal,
                    (Action)(() =>
                    {
                        MessageBox.Show($"Got {move.Direction}!");
                    }
                    ));
                };
            };
            client.Client.Instance.Connect();
            client.Client.Instance.ASyncRead();
            client.Client.Instance.Write($"start {MazeName} {MazeRows} {MazeCols}");
            //string mazeJ = 
            //    Maze maze = Maze.FromJSON(mazeJ);
            //
            //Maze = maze;
            //new MultiPlayerWindow(Maze).Show();
            //
            //client.Client.Instance.Connect();
            //
            //client.Client.Instance.Act = delegate (string result)
            //{
            //    Move Move = Move.FromJSON(result);
            //};

            return true; // need to validate answer.
        }

        public Boolean Join()
        {
            client.Client.Instance.Act = delegate (string result)
            {
                Maze = Maze.FromJSON(result);
                Application.Current.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal,
                (Action)(() =>
                {
                    new MultiPlayerWindow(Maze).Show();
                }
                ));

                client.Client.Instance.Act = delegate (string r)
                {
                    Move move = Move.FromJSON(r);
                    Application.Current.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal,
                    (Action)(() =>
                    {
                        MessageBox.Show($"Got {move.Direction}!");
                    }
                    ));
                };
            };
            client.Client.Instance.Connect();
            client.Client.Instance.ASyncRead();
            MazeName = GamesList[ChosenGame];
            client.Client.Instance.Write($"join {MazeName}");


            //client.Client.Instance.Connect();
            //
            //MazeName = GamesList[ChosenGame];
            //
            //client.Client.Instance.Write($"join {MazeName}");
            //
            //string mazeJ = client.Client.Instance.Read();
            //if (mazeJ == "Error") { } // Error? return false.
            //
            //Maze = Maze.FromJSON(mazeJ);
            //new MultiPlayerWindow(Maze).Show();
            //
            //client.Client.Instance.Act = delegate (string result)
            //{
            //    //parse it to move/close.
            //    Move Move = Move.FromJSON(result);
            //};
            //client.Client.Instance.ASyncRead();

            return true; // need to validate answer.

        }

        public void Close()
        {
            client.Client.Instance.Write($"close {MazeName}");
            client.Client.Instance.Disconnect();
        }

    }
}
