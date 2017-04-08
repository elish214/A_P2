using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeLib;
using MazeGeneratorLib;
using SearchAlgorithmsLib;
using SearchAlgorithmsLib.searchers;

namespace MazeComp
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
            const int ROWS = 10, COLS = 10; //params

            //maze set up
            IMazeGenerator generator = new DFSMazeGenerator();
            MazeLib.Maze maze = generator.Generate(ROWS, COLS);
            Console.WriteLine(maze);

            //search
            SearchableMaze smaze = new SearchableMaze(maze);

            BFS<Position, int> bfs = new BFS<Position, int>((s1, s2) => 1, (i, j) => i + j);
            Solution<Position> bfsSol = bfs.Search(smaze);
            Console.WriteLine($"BFS had: {bfs.GetNumberOfNodesEvaluated()}");

            DFS<Position> dfs = new DFS<Position>();
            Solution<Position> dfsSol = dfs.Search(smaze);
            Console.WriteLine($"DFS had: {dfs.GetNumberOfNodesEvaluated()}");

            /*
            Console.WriteLine();
            MazeSolution ms = MazeSolution.FromSolution(dfsSol);
            string str = MazeSolution.FromSolution(dfsSol).Solution.ToString();
            Console.WriteLine(str);
            Console.WriteLine();

            str = ms.ToJSON();
            Console.WriteLine(str);
            Console.WriteLine();

            Console.WriteLine(MazeSolution.FromJSON(str).Solution.ToString());
        
            Console.WriteLine();
            Move move = new Move();
            move.MazeName = "BLA bla";
            move.Direction = Direction.Right;           
            Console.WriteLine();

            string stri = move.ToJSON();
            Console.WriteLine(stri);
            Console.WriteLine();

            Console.WriteLine(Move.FromJSON(stri).MazeName);
            Console.WriteLine((int)Move.FromJSON(stri).Direction);
            */


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
