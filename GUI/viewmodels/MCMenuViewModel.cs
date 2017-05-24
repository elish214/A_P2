using GUI.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.viewmodels
{
    /// <summary>
    /// maze control menu view model class.
    /// </summary>
    public class MCMenuViewModel : ViewModel
    {
        /// <summary>
        /// a model.
        /// </summary>
        private IMCMenuModel model;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="model"> a model. </param>
        public MCMenuViewModel(IMCMenuModel model)
        {
            this.model = model;
        }

        /// <summary>
        /// public maze name dependency object.
        /// </summary>
        public string MazeName
        {
            get { return model.MazeName; }
            set
            {
                model.MazeName = value;
                NotifyPropertyChanged("MazeName");
            }
        }

        /// <summary>
        /// public maze rows dependency object.
        /// </summary>
        public int MazeRows
        {
            get { return model.MazeRows; }
            set
            {
                model.MazeRows = value;
                NotifyPropertyChanged("MazeRows");
            }
        }

        /// <summary>
        /// public maze collumns dependency object.
        /// </summary>
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
