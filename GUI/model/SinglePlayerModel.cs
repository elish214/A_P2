using Client;
using GUI.utils;
using MazeComp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.model
{
    class SinglePlayerModel : ISinglePlayerModel
    {
        public string MazeName { get; set; }
        public int MazeRows { get; set; }
        public int MazeCols { get; set; }

        public MazeSolution Solve(string name)
        {
            string result = Singleton<ClientMain>.Instance.Send($"solve {name} 0");

            return MazeSolution.FromJSON(result);
        }
    }
}
