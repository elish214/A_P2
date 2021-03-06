﻿using System;
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
    /// <summary>
    /// This is the entry point to the demo.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Demo's main method.
        /// </summary>
        /// <param name="args"> arguments from user. </param>
        static void Main(string[] args)
        {
            CompareSolvers();

            //Console.ReadKey(); 
        }

        /// <summary>
        /// Create a maze, print it, solve it with DFS and BFS and print how many nodes been evaluated.
        /// </summary>
        static void CompareSolvers()
        {
            const int ROWS = 100, COLS = 100; //params

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
          
        }

    }
}
