using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeLib;

namespace SearchAlgorithmsLib
{
    public class Solution<T> : List<State<T>>
    {
        public int NodesEvaluated { get; set; }
    }
}
