using GUI.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.viewmodels
{
    /// <summary>
    /// setting View Model class.
    /// </summary>
    public class SettingsViewModel : ViewModel
    {
        /// <summary>
        /// private model member.
        /// </summary>
        private ISettingsModel model;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="model"> a model. </param>
        public SettingsViewModel(ISettingsModel model)
        {
            this.model = model;
        }

        /// <summary>
        /// public server IP dependency object.
        /// </summary>
        public string ServerIP
        {
            get { return model.ServerIP; }
            set
            {
                model.ServerIP = value;
                NotifyPropertyChanged("ServerIP");
            }
        }

        /// <summary>
        /// public server port dependency object.
        /// </summary>
        public int ServerPort
        {
            get { return model.ServerPort; }
            set
            {
                model.ServerPort = value;
                NotifyPropertyChanged("ServerPort");
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

        /// <summary>
        /// public searching algorithm dependency object.
        /// </summary>
        public int SearchAlgorithm
        {
            get { return model.SearchAlgorithm; }
            set
            {
                model.SearchAlgorithm = value;
                NotifyPropertyChanged("SearchAlgorithm");
            }
        }

        /// <summary>
        /// saving setting method.
        /// </summary>
        public void SaveSettings()
        {
            model.SaveSettings();
        }
    }
}
