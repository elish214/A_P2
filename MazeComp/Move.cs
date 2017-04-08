using MazeLib;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeComp
{
    public class Move
    {
        public string MazeName { get; set; }
        public Direction Direction { get; set; }

        public string ToJSON()
        {
            JObject moveObj = new JObject();
            moveObj["Name"] = MazeName;
            moveObj["Direction"] = Direction.ToString();

            return moveObj.ToString();
        }

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
