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
        private IMPMenuModel model;
        private Maze maze;

        public MPMenuViewModel(IMPMenuModel model) : base(model)
        {
            this.model = model;

            model.PropertyChanged +=
                delegate (Object sender, PropertyChangedEventArgs e)
                {
                    NotifyPropertyChanged(e.PropertyName);
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

        public ObservableCollection<string> GamesList
        {
            get { return model.GamesList; }
            set
            {
                model.GamesList = value;
                NotifyPropertyChanged("GamesList");
            }
        }

        public int ChosenGame
        {
            get { return model.ChosenGame; }
            set
            {
                model.ChosenGame = value;
                NotifyPropertyChanged("ChosenGame");
            }
        }

        public void Load()
        {
            model.Load();
        }

        public void Start()
        {
            // add label of waiting for another.
            model.Start();
        }

        public void Join()
        {
            // need to verify that game exist.
            model.Join();
        }

        public void Close()
        {
            model.Close();
        }
    }
}
