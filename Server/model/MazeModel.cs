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
using System.Threading;
using System.Threading.Tasks;

namespace Server.model
{
    /// <summary>
    /// Model class.
    /// </summary>
    public class MazeModel : IModel
    {
        /// <summary>
        /// Holds the controller it's assosiated with.
        /// </summary>
        public Controller Controller { get; }

        /// <summary>
        /// Holds a dictionary of games' names to it's games.
        /// </summary>
        public Dictionary<string, MazeGame> Games { get; }

        /// <summary>
        /// Holds a dictionary of clients to it's games.
        /// </summary>
        public Dictionary<TcpClient, MazeGame> Players { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="controller"> a controller. </param>
        public MazeModel(Controller controller)
        {
            Controller = controller;
            Games = new Dictionary<string, MazeGame>();
            Players = new Dictionary<TcpClient, MazeGame>();
        }

        public Maze Generate(string name, int rows, int cols, TcpClient client)
        {
            MazeGame game = new MazeGame()
            {
                Name = name,
                Maze = new DFSMazeGenerator().Generate(rows, cols),
                NumOfPlayers = 1
            };

            game.Maze.Name = name;
            game.Players[client] = game.Maze.InitialPos;
            Players[client] = game;
            Games[name] = game;

            return game.Maze;
        }

        public MazeSolution Solve(string name, ISearcher<Position> searcher)
        {
            MazeGame game = Games[name];

            if (game.Solution == null)
            {
                SearchableMaze smaze = new SearchableMaze(game.Maze);
                game.Solution = MazeSolution.FromSolution(searcher.Search(smaze));
                game.Solution.MazeName = name;
            }

            return game.Solution;
        }

        public void Start(string name, int rows, int cols, TcpClient client)
        {
            MazeGame game = new MazeGame()
            {
                Name = name,
                Maze = new DFSMazeGenerator().Generate(rows, cols),
                NumOfPlayers = 2
            };

            game.Maze.Name = name;
            game.Players[client] = game.Maze.InitialPos;
            Players[client] = game;
            Games[name] = game;
        }

        public List<string> List()
        {
            return Games.Keys.ToList();
        }

        public Maze Join(string name, TcpClient client)
        {
            MazeGame game = Games[name];

            game.Players[client] = game.Maze.InitialPos;
            Players[client] = game;

            Controller.Send(game.Maze.ToJSON(), game.Players.Keys.ToList()[0]);

            return game.Maze;
        }

        public void Play(Direction direction, TcpClient client)
        {
            MazeGame game = Players[client];
            Position currentPos = game.Players[client];
            Position pos = new Position(currentPos.Row, currentPos.Col);

            Console.WriteLine($"({pos.Row}, {pos.Col}), {direction}");

            switch (direction)
            {
                case Direction.Up:
                    pos.Row--;
                    Console.WriteLine("Up");
                    break;

                case Direction.Down:
                    pos.Row++;
                    Console.WriteLine("Down");
                    break;

                case Direction.Left:
                    pos.Col--;
                    Console.WriteLine("Left");
                    break;

                case Direction.Right:
                    pos.Col++;
                    Console.WriteLine("Right");
                    break;
            }

            Console.WriteLine($"({pos.Row}, {pos.Col})");

            if (0 <= pos.Row && 0 <= pos.Col &&
                pos.Row < game.Maze.Rows && pos.Col < game.Maze.Cols &&
                game.Maze[pos.Row, pos.Col] != CellType.Wall)
            {
                game.Players[client] = pos;
                Move move = new Move()
                {
                    MazeName = game.Name,
                    Direction = direction
                };

                string json = move.ToJSON();
                Console.WriteLine($"before send, {game.Players.Count()}");

                //notify other player about pos change
                foreach (TcpClient c in game.Players.Keys)
                {
                    Console.WriteLine("trying send play...");
                    if (c != client)
                    {
                        Controller.Send(json, c);
                        Console.WriteLine("sent play");
                    }
                }
            }
        }

        public void Close(string name, TcpClient client)
        {
            MazeGame game = Games[name];

            //notify other player about pos change
            foreach (TcpClient c in game.Players.Keys)
            {
                Console.WriteLine("trying send close...");
                if (c != client)
                {
                    Controller.Send(" ", c);
                    Console.WriteLine("sent close");
                    c.Close();
                }
            }
        }
    }
}
