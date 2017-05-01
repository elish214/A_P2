using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.model
{
    class SettingsModel : ISettingsModel
    {
        public string ServerIP { get; set; }
        public int ServerPort { get; set; }
        public int MazeRows { get; set; }
        public int MazeCols { get; set; }
        public int SearchAlgorithm { get; set; }

        public void SaveSettings()
        {
            Console.WriteLine("SETTINGS:");
            Console.WriteLine("\t" + ServerIP);
            Console.WriteLine("\t" + ServerPort);
            Console.WriteLine("\t" + MazeRows);
            Console.WriteLine("\t" + MazeCols);
            Console.WriteLine("\t" + SearchAlgorithm);
        }
    }
}
