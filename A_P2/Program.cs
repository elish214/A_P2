using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeComp;
using MazeLib;
using MazeGeneratorLib;
using SearchAlgorithmsLib;
using SearchAlgorithmsLib.searchers;

namespace A_P2
{
    class Program
    {
        static void Main(string[] args)
        {
            CompareSolvers();

            Console.ReadKey(); //REMOVE BEFORE SUBMISSION
        }

        static void CompareSolvers()
        {
            const int ROWS = 7, COLS = 7; //params

            //maze set up
            IMazeGenerator generator = new DFSMazeGenerator();
            MazeLib.Maze maze = generator.Generate(ROWS, COLS);
            Console.WriteLine(maze);

            //search
            SearchableMaze smaze = new SearchableMaze(maze);

            BFS<Position> bfs = new BFS<Position>();
            Solution<Position> bfsSol = bfs.Search(smaze);
            Console.WriteLine($"BFS had: {bfs.GetNumberOfNodesEvaluated()}");

            DFS<Position> dfs = new DFS<Position>();
            Solution<Position> dfsSol = dfs.Search(smaze);
            Console.WriteLine($"DFS had: {dfs.GetNumberOfNodesEvaluated()}");

            //Console.WriteLine();
            //Console.WriteLine(Maze.MazeSolution.FromSolution(dfsSol).ToString());

            //print
            /*
            foreach (State<Position> s in bfsSol)
            {
                Console.WriteLine($"({s.TState.Row}, {s.TState.Col})");
            }
            
            Console.WriteLine();
            foreach (State<Position> s in dfsSol)
            {
                Console.WriteLine($"({s.TState.Row}, {s.TState.Col})");
            }
            */

        }

    }
}
