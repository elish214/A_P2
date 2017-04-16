using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeLib;

namespace SearchAlgorithmsLib
{
    /// <summary>
    /// Solution class.
    /// </summary>
    /// <typeparam name="T"> a generic type of solution. </typeparam>
    public class Solution<T> : List<State<T>>
    {
        /// <summary>
        /// Holds the number of nodes that been evaluated in that solution.
        /// </summary>
        public int NodesEvaluated { get; set; }
    }
}
