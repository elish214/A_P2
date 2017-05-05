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
        private IMPMenuModel _model;

        public MPMenuViewModel(IMPMenuModel model) : base(model)
        {
            _model = model;
        }

        public int ChosenGame
        {
            get { return _model.ChosenGame; }
            set
            {
                _model.ChosenGame = value;
                NotifyPropertyChanged("ChosenGame");
            }
        }
    }
}
