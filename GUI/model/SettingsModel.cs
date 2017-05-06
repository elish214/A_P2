using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.model
{
    public class SettingsModel : ISettingsModel
    {
        public SettingsModel()
        {
            ServerIP = Properties.Settings.Default.ServerIP;
            ServerPort = Properties.Settings.Default.ServerPort;
            MazeRows = Properties.Settings.Default.MazeRows;
            MazeCols = Properties.Settings.Default.MazeCols;
            SearchAlgorithm = Properties.Settings.Default.SearchAlgorithm;
        }

        public string ServerIP { get; set; }

        public int ServerPort { get; set; }

        public int MazeRows { get; set; }

        public int MazeCols { get; set; }

        public int SearchAlgorithm { get; set; }

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
