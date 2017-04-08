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
    public class MazeSolution
    {
        public string MazeName { get; set; }
        public int NodesEvaluated { get; set; }
        public string Solution { get; set; }

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
                            MS.Solution += "0";
                        }
                        else if (colDiff == -1)
                        {
                            MS.Solution += "1";
                        }
                    }
                    if (rowDiff == 1)
                    {
                        if (colDiff == 0)
                        {
                            MS.Solution += "2";
                        }
                    }
                    if (rowDiff == -1)
                    {
                        if (colDiff == 0)
                        {
                            MS.Solution += "3";
                        }
                    }
                }
            }

            return MS;
        }

        public string ToJSON()
        {
            JObject solutionObj = new JObject();
            solutionObj["Name"] = MazeName;
            solutionObj["Solution"] = Solution;
            solutionObj["NodesEvaluated"] = NodesEvaluated;

            return solutionObj.ToString();
        }

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
