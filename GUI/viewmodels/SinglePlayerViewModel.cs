using GUI.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.viewmodels
{
    class SinglePlayerViewModel : ViewModel
    {
        public ISinglePlayerModel Model { get; }

        public SinglePlayerViewModel(SinglePlayerModel model)
        {
            Model = model;
            Model.PropertyChanged +=
                delegate (Object sender, PropertyChangedEventArgs e)
                {
                    NotifyPropertyChanged(e.PropertyName);
                };
        }

        public void Solve()
        {
            Model.Solve();
        }

        public string GetSolution()
        {
            return Model.Solution.Solution;
        }
    }
}
