using GUI.model;
using GUI.windows;
using MazeLib;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.viewmodels
{
    public class MPMenuViewModel : MCMenuViewModel
    {
        public IMPMenuModel Model { get; }
        //private Maze maze;

        public MPMenuViewModel(IMPMenuModel model) : base(model)
        {
            Model = model;

            model.PropertyChanged +=
                delegate (Object sender, PropertyChangedEventArgs e)
                {
                    NotifyPropertyChanged(e.PropertyName);
                };

        }

        public Maze Maze
        {
            get { return Model.Maze; }
            set
            {
                Model.Maze = value;
                NotifyPropertyChanged("Maze");
            }
        }

        public ObservableCollection<string> GamesList
        {
            get { return Model.GamesList; }
            set
            {
                Model.GamesList = value;
                NotifyPropertyChanged("GamesList");
            }
        }

        public int ChosenGame
        {
            get { return Model.ChosenGame; }
            set
            {
                Model.ChosenGame = value;
                NotifyPropertyChanged("ChosenGame");
            }
        }

        public void Load()
        {
            Model.Load();
        }

        public void Start()
        {
            // add label of waiting for another.
            Model.Start();
        }

        public void Join()
        {
            // need to verify that game exist.
            Model.Join();
        }

        public void Close()
        {
            Model.Close();
        }
    }
}
