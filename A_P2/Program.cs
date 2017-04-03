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
            const int ROWS = 10, COLS = 10; //params

            //maze set up
            IMazeGenerator generator = new DFSMazeGenerator();
            Maze maze = generator.Generate(ROWS, COLS);
            Console.WriteLine(maze);

            //search
            SearchableMaze smaze = new SearchableMaze(maze);
            Solution<Position> solution = new BFS<Position>().Search(smaze);
         
            //print
            /*
            foreach (State<Position> s in solution)
            {
                Console.WriteLine($"({s.TState.Row}, {s.TState.Col})");
            }*/
            Console.WriteLine();

            Solution<Position> solution2 = new DFS<Position>().Search(smaze);
            /*
            foreach (State<Position> s in solution2)
            {
                Console.WriteLine($"({s.TState.Row}, {s.TState.Col})");
            }*/

            Console.WriteLine($"BFS had: {solution.Count()}");
            Console.WriteLine($"DFS had: {solution2.Count()}");

        }

    }
}
