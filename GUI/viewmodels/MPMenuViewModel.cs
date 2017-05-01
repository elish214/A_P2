using GUI.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.viewmodels
{
    class MPMenuViewModel : ViewModel
    {
        private IMPMenuModel model;

        public MPMenuViewModel(IMPMenuModel model)
        {
            this.model = model;
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

        public string MazeName
        {
            get { return model.MazeName; }
            set
            {
                model.MazeName = value;
                NotifyPropertyChanged("MazeName");
            }
        }

        public int MazeRows
        {
            get { return model.MazeRows; }
            set
            {
                model.MazeRows = value;
                NotifyPropertyChanged("MazeRows");
            }
        }

        public int MazeCols
        {
            get { return model.MazeCols; }
            set
            {
                model.MazeCols = value;
                NotifyPropertyChanged("MazeCols");
            }
        }
    }
}
