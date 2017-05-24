using GUI.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.viewmodels
{
    /// <summary>
    /// single player view model class.
    /// </summary>
    class SinglePlayerViewModel : ViewModel
    {
        /// <summary>
        /// a model.
        /// </summary>
        public ISinglePlayerModel Model { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="model"> a model. </param>
        public SinglePlayerViewModel(SinglePlayerModel model)
        {
            Model = model;
            Model.PropertyChanged +=
                delegate (Object sender, PropertyChangedEventArgs e)
                {
                    NotifyPropertyChanged(e.PropertyName);
                };
        }

        /// <summary>
        /// solving method.
        /// </summary>
        public void Solve()
        {
            Model.Solve();
        }

        /// <summary>
        /// returns solution.
        /// </summary>
        /// <returns> solution. </returns>
        public string GetSolution()
        {
            return Model.Solution.Solution;
        }
    }
}
