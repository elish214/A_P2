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
    /// <summary>
    /// single player menu model.
    /// </summary>
    public class SPMenuModel : MCMenuModel, ISPMenuModel
    {
        /// <summary>
        /// Generating game method.
        /// </summary>
        /// <returns></returns>
        public Maze Generate()
        {
            string result = client.Client.Instance.WriteRead($"generate {MazeName} {MazeRows} {MazeCols}");

            Maze maze = Maze.FromJSON(result);

            return maze;
        }
    }
}
