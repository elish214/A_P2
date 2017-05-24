using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.model
{
    /// <summary>
    /// setting model class.
    /// </summary>
    public class SettingsModel : ISettingsModel
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public SettingsModel()
        {
            ServerIP = Properties.Settings.Default.ServerIP;
            ServerPort = Properties.Settings.Default.ServerPort;
            MazeRows = Properties.Settings.Default.MazeRows;
            MazeCols = Properties.Settings.Default.MazeCols;
            SearchAlgorithm = Properties.Settings.Default.SearchAlgorithm;
        }

        /// <summary>
        /// Server IP.
        /// </summary>
        public string ServerIP { get; set; }

        /// <summary>
        /// Server Port.
        /// </summary>
        public int ServerPort { get; set; }

        /// <summary>
        /// Maze Rows.
        /// </summary>
        public int MazeRows { get; set; }

        /// <summary>
        /// Maze collumns.
        /// </summary>
        public int MazeCols { get; set; }

        /// <summary>
        /// Chosen searching algorithm.
        /// </summary>
        public int SearchAlgorithm { get; set; }

        /// <summary>
        /// saving settings method.
        /// </summary>
        public void SaveSettings()
        {
            Properties.Settings.Default.ServerIP = ServerIP;
            Properties.Settings.Default.ServerPort = ServerPort;
            Properties.Settings.Default.MazeRows = MazeRows;
            Properties.Settings.Default.MazeCols = MazeCols;
            Properties.Settings.Default.SearchAlgorithm = SearchAlgorithm;

            Properties.Settings.Default.Save();
        }
    }
}
