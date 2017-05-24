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
    /// <summary>
    /// multi player view model class.
    /// </summary>
    class MultiPlayerViewModel : ViewModel
    {
        /// <summary>
        /// a model.
        /// </summary>
        public IMultiPlayerModel Model { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="model"> a model. </param>
        public MultiPlayerViewModel(MultiPlayerModel model)
        {
            Model = model;
            Model.PropertyChanged +=
                delegate (Object sender, PropertyChangedEventArgs e)
                {
                    NotifyPropertyChanged(e.PropertyName);
                };
        }

        /// <summary>
        /// moving method.
        /// </summary>
        /// <param name="move"> a move.</param>
        public void Moved(string move)
        {
            Model.Moved(move);
        }

        /// <summary>
        /// closing game method.
        /// </summary>
        public void CloseGame()
        {
            Model.CloseGame();
        }
    }
}
