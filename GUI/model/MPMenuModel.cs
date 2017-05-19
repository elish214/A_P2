using GUI.windows;
using MazeLib;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public int ChosenGame { get; set;}

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
            client.Client.Instance.Connect();
            
            client.Client.Instance.Act = delegate(string result)
            {
                Maze = Maze.FromJSON(result);
                new MultiPlayerWindow(Maze).Show();
            };

            client.Client.Instance.Write($"start {MazeName} {MazeRows} {MazeCols}");

            client.Client.Instance.ASyncRead();

            return true; // need to validate answer.
        }

        public Boolean Join()
        {
            client.Client.Instance.Connect();

            client.Client.Instance.Act = delegate (string result)
            {
                Maze = Maze.FromJSON(result);
                new MultiPlayerWindow(Maze).Show();
            };
            MazeName = GamesList[ChosenGame];

            client.Client.Instance.Write($"join {MazeName}");

            client.Client.Instance.ASyncRead();

            return true; // need to validate answer.
            
        }

        public void Close()
        {
            client.Client.Instance.Disconnect();
        }

    }
}
