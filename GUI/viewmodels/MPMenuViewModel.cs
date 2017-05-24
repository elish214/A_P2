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
    /// <summary>
    /// multi player menu View Model.
    /// </summary>
    public class MPMenuViewModel : MCMenuViewModel
    {
        /// <summary>
        /// a model.
        /// </summary>
        public IMPMenuModel Model { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="model"> a model.</param>
        public MPMenuViewModel(IMPMenuModel model) : base(model)
        {
            Model = model;

            model.PropertyChanged +=
                delegate (Object sender, PropertyChangedEventArgs e)
                {
                    NotifyPropertyChanged(e.PropertyName);
                };

        }

        /// <summary>
        /// public maze dependency object.
        /// </summary>
        public Maze Maze
        {
            get { return Model.Maze; }
            set
            {
                Model.Maze = value;
                NotifyPropertyChanged("Maze");
            }
        }

        /// <summary>
        /// public list of games dependency object.
        /// </summary>
        public ObservableCollection<string> GamesList
        {
            get { return Model.GamesList; }
            set
            {
                Model.GamesList = value;
                NotifyPropertyChanged("GamesList");
            }
        }

        /// <summary>
        /// public chosen game dependency object.
        /// </summary>
        public int ChosenGame
        {
            get { return Model.ChosenGame; }
            set
            {
                Model.ChosenGame = value;
                NotifyPropertyChanged("ChosenGame");
            }
        }

        /// <summary>
        /// loading method.
        /// </summary>
        public void Load()
        {
            Model.Load();
        }

        /// <summary>
        /// starting method.
        /// </summary>
        public void Start()
        {
            Model.Start();
        }

        /// <summary>
        /// joining method.
        /// </summary>
        public void Join()
        {
            Model.Join();
        }

        /// <summary>
        /// closing method.
        /// </summary>
        public void Close()
        {
            Model.Close();
        }
    }
}
