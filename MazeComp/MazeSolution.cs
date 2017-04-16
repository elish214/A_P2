using MazeLib;
using Newtonsoft.Json.Linq;
using SearchAlgorithmsLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeComp
{
    /// <summary>
    /// A specific solution type class.
    /// </summary>
    public class MazeSolution
    {
        /// <summary>
        /// Maze's name.
        /// </summary>
        public string MazeName { get; set; }

        /// <summary>
        /// Holds the number of nodes that been evaluated in that solution.
        /// </summary>
        public int NodesEvaluated { get; set; }

        /// <summary>
        /// Holds a solution as a string.
        /// </summary>
        public string Solution { get; set; }

        /// <summary>
        /// Static function to get a MazeSolution object from a Solution object.
        /// </summary>
        /// <param name="backTrace"> a solution of positions. </param>
        /// <returns> a MazeSolution object. </returns>
        public static MazeSolution FromSolution(Solution<Position> backTrace)
        {
            MazeSolution MS = new MazeSolution();
            MS.Solution = "";
            MS.NodesEvaluated = backTrace.NodesEvaluated;

            int rowDiff, colDiff;

            if (backTrace.Count() > 1)
            {
                for (int i = 1; i < backTrace.Count(); i++)
                {
                    rowDiff = backTrace.ElementAt(i).TState.Row - backTrace.ElementAt(i - 1).TState.Row;
                    colDiff = backTrace.ElementAt(i).TState.Col - backTrace.ElementAt(i - 1).TState.Col;

                    if (rowDiff == 0)
                    {
                        if (colDiff == 1)
                        {
                            MS.Solution = "0" + MS.Solution;
                        }
                        else if (colDiff == -1)
                        {
                            MS.Solution = "1" + MS.Solution;
                        }
                    }
                    if (rowDiff == 1)
                    {
                        if (colDiff == 0)
                        {
                            MS.Solution = "2" + MS.Solution;
                        }
                    }
                    if (rowDiff == -1)
                    {
                        if (colDiff == 0)
                        {
                            MS.Solution = "3" + MS.Solution;
                        }
                    }
                }
            }

            return MS;
        }

        /// <summary>
        /// Convert MazeSolution object to a JSON.
        /// </summary>
        /// <returns> MazeSolution as a JSON. </returns>
        public string ToJSON()
        {
            JObject solutionObj = new JObject();
            solutionObj["Name"] = MazeName;
            solutionObj["Solution"] = Solution;
            solutionObj["NodesEvaluated"] = NodesEvaluated;

            return solutionObj.ToString();
        }

        /// <summary>
        /// Static function to re-create a MazeSolution object from JSON.
        /// </summary>
        /// <param name="str"> a string. </param>
        /// <returns> a MazeSolution object. </returns>
        public static MazeSolution FromJSON(string str)
        {
            MazeSolution mazeSolution = new MazeSolution();

            JObject solutionObj = JObject.Parse(str);
            mazeSolution.MazeName = (string)solutionObj["Name"];
            mazeSolution.Solution = (string)solutionObj["Solution"];
            mazeSolution.NodesEvaluated = (int)solutionObj["NodesEvaluated"];

            return mazeSolution;
        }
    }
}
