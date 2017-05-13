using Client;
using GUI.utils;
using GUI.windows;
using MazeLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.model
{
    public class SPMenuModel : MCMenuModel, ISPMenuModel
    {


        public Maze Generate()
        {
            //string result = Singleton<ClientMain>.Instance.Send($"generate {MazeName} {MazeRows} {MazeCols}");

            string result = client.Client.Instance.WriteRead($"generate {MazeName} {MazeRows} {MazeCols}");

            Maze maze = Maze.FromJSON(result);

            return maze;
        }
    }
}
