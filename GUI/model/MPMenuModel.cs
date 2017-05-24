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
    /// <summary>
    /// multi player menu model class.
    /// </summary>
    public class MPMenuModel : MCMenuModel, IMPMenuModel
    {
        /// <summary>
        /// private maze member.
        /// </summary>
        private Maze maze;

        /// <summary>
        /// private list of games member.
        /// </summary>
        private ObservableCollection<string> gamesList = new ObservableCollection<string>();

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
        /// public list of games dependency object.
        /// </summary>
        public ObservableCollection<string> GamesList
        {
            get { return gamesList; }
            set
            {
                gamesList = value;
                NotifyPropertyChanged("GamesList");
            }
        }

        /// <summary>
        /// chosen game.
        /// </summary>
        public int ChosenGame { get; set; }

        /// <summary>
        /// a method to load the current availabe games.
        /// </summary>
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

        /// <summary>
        /// starting method.
        /// </summary>
        public void Start()
        {
            client.Client.Instance.Act = delegate (string result)
            {
                Application.Current.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal,
                (Action)(() =>
                {
                    Maze = Maze.FromJSON(result);
                    //new MultiPlayerWindow(Maze).Show();
                }
                ));

            };

            client.Client.Instance.Connect();
            client.Client.Instance.ASyncRead();
            client.Client.Instance.Write($"start {MazeName} {MazeRows} {MazeCols}");

        }

        /// <summary>
        /// joining method.
        /// </summary>
        public void Join()
        {
            client.Client.Instance.Act = delegate (string result)
            {
                Application.Current.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal,
                (Action)(() =>
                {
                    Maze = Maze.FromJSON(result);
                }
                ));
            };

            client.Client.Instance.Connect();
            client.Client.Instance.ASyncRead();
            MazeName = GamesList[ChosenGame];
            client.Client.Instance.Write($"join {MazeName}");

        }

        /// <summary>
        /// closing method.
        /// </summary>
        public void Close()
        {
            client.Client.Instance.Write($"close {MazeName}");
            client.Client.Instance.Disconnect();
        }

    }
}
