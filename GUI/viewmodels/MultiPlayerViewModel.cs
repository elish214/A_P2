using GUI.model;
using MazeLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.viewmodels
{
    class MultiPlayerViewModel : ViewModel
    {
        public IMultiPlayerModel Model { get; set; }

        public MultiPlayerViewModel(MultiPlayerModel model)
        {
            Model = model;
            Model.PropertyChanged +=
                delegate (Object sender, PropertyChangedEventArgs e)
                {
                    NotifyPropertyChanged(e.PropertyName);
                };
        }

        public void Moved(string move)
        {
            Model.Moved(move);
        }

        public void CloseGame()
        {
            Model.CloseGame();
        }
    }
}
