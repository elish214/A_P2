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
    /// <summary>
    /// Solve maze command class.
    /// </summary>
    public class SolveMazeCommand : IServerCommand
    {
        /// <summary>
        /// An enum for clearer code.
        /// </summary>
        enum SearchAlgo { Bfs, Dfs };

        /// <summary>
        /// Holds the model it's assosiated with.
        /// </summary>
        private IServerModel model;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="model"> the model it's assosiated with. </param>
        public SolveMazeCommand(IServerModel model)
        {
            this.model = model;
        }

        /// <summary>
        /// Excute command. called by controller. solves a maze.
        /// </summary>
        /// <param name="args"> arguments from console. </param>
        /// <param name="client"> client to handle. </param>
        /// <returns> a result to send back to client. </returns>
        public Result Execute(string[] args, TcpClient client = null)
        {
            try
            {
                string name = args[0];
                int algo = int.Parse(args[1]);

                ISearcher<Position> searcher = null;
                SearchAlgo search = (SearchAlgo)algo;

                switch (search)
                {
                    case SearchAlgo.Bfs:
                        searcher = new BFS<Position, int>((s1, s2) => 1, (i, j) => i + j);
                        break;

                    case SearchAlgo.Dfs:
                        searcher = new DFS<Position>();
                        break;

                    default:
                        throw new FormatException();
                }

                return new Result(Status.Keep, model.Solve(name, searcher, client).ToJSON());
            }
            catch (Exception e)
            {
                return Result.Error;
            }
        }
    }
}
