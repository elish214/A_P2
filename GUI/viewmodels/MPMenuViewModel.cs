using GUI.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.viewmodels
{
    public class MPMenuViewModel : MCMenuViewModel
    {
        private IMPMenuModel model;

        public MPMenuViewModel(IMPMenuModel model) : base(model)
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
    }
}
