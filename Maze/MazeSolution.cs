using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeLib;
using SearchAlgorithmsLib;

namespace Maze
{
    public class MazeSolution 
    {
        public int NodesEvaluated { get; set; }
        public List<Direction> solution { get; set; }

        public static MazeSolution FromSolution (Solution<Position> backTrace)
        {
            MazeSolution MS = new MazeSolution();
            MS.solution = new List<Direction>();
            MS.NodesEvaluated = backTrace.NodesEvaluated;

            int rowDiff, colDiff;

            if(backTrace.Count() > 1)
            {
                for(int i = 1; i < backTrace.Count(); i++)
                {
                    rowDiff = backTrace.ElementAt(i).TState.Row - backTrace.ElementAt(i-1).TState.Row;
                    colDiff = backTrace.ElementAt(i).TState.Col - backTrace.ElementAt(i-1).TState.Col;

                    if (rowDiff == 0)
                    {
                        if (colDiff == 1)
                        {
                            MS.solution.Add(Direction.Left);
                        }
                        else if (colDiff == -1) 
                        {
                            MS.solution.Add(Direction.Right);
                        }
                    }
                    if (rowDiff == 1)
                    {
                        if (colDiff == 0)
                        {
                            MS.solution.Add(Direction.Up);
                        }
                    }
                    if (rowDiff == -1)
                    {
                        if (colDiff == 0)
                        {
                            MS.solution.Add(Direction.Down);
                        }
                    }
                }
            }

            return MS;
        }

        public override string ToString()
        {
            string s = "";

            foreach(Direction d in this.solution)
            {
                s += ((int)d).ToString();
            }

            return s;
        }

        //add ToJSON.
    }
}
