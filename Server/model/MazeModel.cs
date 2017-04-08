using MazeComp;
using MazeGeneratorLib;
using MazeLib;
using SearchAlgorithmsLib;
using SearchAlgorithmsLib.searchers;
using Server.controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server.model
{
    enum SearchAlgo { Bfs, Dfs };

    public class MazeModel : IModel
    {
        private IController controller;
        private Dictionary<string, MazeGame> games;
        private Dictionary<TcpClient, MazeGame> players;

        public MazeModel(IController controller)
        {
            this.controller = controller;
            games = new Dictionary<string, MazeGame>();
            players = new Dictionary<TcpClient, MazeGame>();
        }

        public Maze GenerateMaze(string name, int rows, int cols, TcpClient client, int numOfPlayers = 1)
        {
            MazeGame game = new MazeGame()
            {
                Name = name,
                Maze = new DFSMazeGenerator().Generate(rows, cols),
                NumOfPlayers = numOfPlayers
            };

            game.Maze.Name = name;
            game.Players.Add(client, game.Maze.InitialPos);
            players.Add(client, game);

            return game.Maze;
        }

        public MazeSolution SolveMaze(string name, int algo)
        {
            MazeGame game = games[name];
            SearchableMaze smaze = new SearchableMaze(game.Maze);
            ISearcher<Position> searcher = null;
            SearchAlgo search = (SearchAlgo) algo;

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
            //update solution with maze name!!!!!!
            return game.Solution;
        }

        public void StartMaze(String name, int rows, int cols, TcpClient client, int numOfPlayers = 2)
        {
            Maze maze = GenerateMaze(name, rows, cols, client, numOfPlayers);

            //while?
        }

        public List<string> GameList()
        {
            return games.Keys.ToList();
        }

        public Maze Join(string name, TcpClient client)
        {
            MazeGame game = games[name];

            game.Players.Add(client, game.Maze.InitialPos);
            players.Add(client, game);

            //if(game.ArePlayersReady())
            //update first client

            return game.Maze;
            
        }

        public void Play(Direction direction, TcpClient client)
        {
            MazeGame game = players[client];
            Position pos = game.Players[client];

            switch (direction)
            {
                case Direction.Up:
                    pos.Col--;
                    break;

                case Direction.Down:
                    pos.Col++;
                    break;

                case Direction.Left:
                    pos.Row--;
                    break;

                case Direction.Right:
                    pos.Row++;
                    break;
            }

            if (game.Maze[pos.Row, pos.Col] != CellType.Wall)
            {
                game.Players[client] = pos;

                //notify other player about pos change
            }
        }

        public void Close(string name, TcpClient client)
        {
            //notify other player about game end
        }
    }
}
