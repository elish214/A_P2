using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.model
{
    /// <summary>
    /// setting model interface.
    /// </summary>
    public interface ISettingsModel
    {
        /// <summary>
        /// server IP.
        /// </summary>
        string ServerIP { get; set; }

        /// <summary>
        /// server port.
        /// </summary>
        int ServerPort { get; set; }

        /// <summary>
        /// maze rows.
        /// </summary>
        int MazeRows { get; set; }

        /// <summary>
        /// maze collumns.
        /// </summary>
        int MazeCols { get; set; }

        /// <summary>
        /// a chosen search algoritm.
        /// </summary>
        int SearchAlgorithm { get; set; }

        /// <summary>
        /// saving setting method.
        /// </summary>
        void SaveSettings();
    }
}
