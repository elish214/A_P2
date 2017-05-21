﻿using GUI.windows;
using MazeComp;
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
            string mazeJ = "";

            client.Client.Instance.Connect();
            
            client.Client.Instance.Write($"start {MazeName} {MazeRows} {MazeCols}");

          //  new Task(() =>
          //  {
               // do
               // {
                    
               // } while (mazeJ == "");

           // });
            /*
            client.Client.Instance.Act = delegate (string result)
            {
                mazeJ = client.Client.Instance.Read();
                Maze maze = Maze.FromJSON(mazeJ);
                new MultiPlayerWindow(maze).Show();
                Move Move = Move.FromJSON(result);
            };*/

            client.Client.Instance.ASyncRead();

            return true; // need to validate answer.
        }

        public Boolean Join()
        {
            client.Client.Instance.Connect();

            MazeName = GamesList[ChosenGame];

            client.Client.Instance.Write($"join {MazeName}");

            string mazeJ = client.Client.Instance.Read();

            Maze = Maze.FromJSON(mazeJ);
            new MultiPlayerWindow(Maze).Show();

            client.Client.Instance.Act = delegate (string result)
           {
               Move Move = Move.FromJSON(result);
           };
            client.Client.Instance.ASyncRead();

            return true; // need to validate answer.
            
        }

        public void Close()
        {
            client.Client.Instance.Disconnect();
        }

    }
}
