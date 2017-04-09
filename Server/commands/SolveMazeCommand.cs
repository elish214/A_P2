using MazeComp;
using MazeLib;
using SearchAlgorithmsLib;
using SearchAlgorithmsLib.searchers;
using Server.controller;
using Server.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server.commands
{
    public class SolveMazeCommand : ICommand
    {
        enum SearchAlgo { Bfs, Dfs };

        private IModel model;

        public SolveMazeCommand(IModel model)
        {
            this.model = model;
        }

        public Result Execute(string[] args, TcpClient client = null)
        {
            string name = args[0];
            int algo = int.Parse(args[1]);

            MazeGame game = model.Games[name];
            SearchableMaze smaze = new SearchableMaze(game.Maze);
            ISearcher<Position> searcher = null;
            SearchAlgo search = (SearchAlgo)algo;

            if (game.Solution == null)
            {
                switch (search)
                {
                    case SearchAlgo.Bfs:
                        searcher = new BFS<Position, int>((s1, s2) => 1, (i, j) => i + j);
                        break;

                    case SearchAlgo.Dfs:
                        searcher = new DFS<Position>();
                        break;
                }

                game.Solution = MazeSolution.FromSolution(searcher.Search(smaze));
                game.Solution.MazeName = name;
            }

            return new Result(Status.Keep, game.Solution.ToJSON());
        }
    }
}
