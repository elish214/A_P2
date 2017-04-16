using MazeLib;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeComp
{
    /// <summary>
    /// A move class.
    /// </summary>
    public class Move
    {
        /// <summary>
        /// Maze's name.
        /// </summary>
        public string MazeName { get; set; }

        /// <summary>
        /// A direction to move ahead.
        /// </summary>
        public Direction Direction { get; set; }

        /// <summary>
        /// Convert Move object to a JSON.
        /// </summary>
        /// <returns> Move as a JSON. </returns>
        public string ToJSON()
        {
            JObject moveObj = new JObject();
            moveObj["Name"] = MazeName;
            moveObj["Direction"] = Direction.ToString();

            return moveObj.ToString();
        }

        /// <summary>
        /// Static function to re-create a Move object from JSON.
        /// </summary>
        /// <param name="str"> a string. </param>
        /// <returns> a Move object. </returns>
        public static Move FromJSON(string str)
        {
            Move move = new Move();

            JObject moveObj = JObject.Parse(str);
            move.MazeName = (string)moveObj["Name"];
            move.Direction = (Direction)Enum.Parse(typeof(Direction), (string)moveObj["Direction"]);

            return move;
        }
    }
}
