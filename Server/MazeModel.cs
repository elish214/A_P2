using MazeComp;
using MazeGeneratorLib;
using MazeLib;
using SearchAlgorithmsLib;
using SearchAlgorithmsLib.searchers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class MazeModel
    {
        private Dictionary<string, MazeGame> games;
        private Dictionary<TcpClient, MazeGame> players;

        public MazeModel()
        {
            games = new Dictionary<string, MazeGame>();
        }

        public Maze GenerateMaze(string name, int rows, int cols, TcpClient client)
        {
            MazeGame game = new MazeGame()
            {
                Name = name,
                Maze = new DFSMazeGenerator().Generate(rows, cols),
                NumOfPlayers = 1
            };

            game.Players.Add(client, game.Maze.InitialPos);
            players.Add(client, game);

            return game.Maze;
        }

        public Solution<Position> SolveMaze(string name, int algo)
        {
            MazeGame game = games[name];
            SearchableMaze smaze = new SearchableMaze(game.Maze);
            ISearcher<Position> searcher = null;

            switch(algo)
            {
                case 0: //BFS
                    searcher = new BFS<Position>();
                    break;

                case 1: //DFS
                    searcher = new BFS<Position>();
                    break;
            }

            game.Solution = searcher.Search(smaze);
            return game.Solution;
        }
    }
}
