using MazeComp;
using MazeLib;
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
    class PlayMazeCommand : ICommand
    {
        private IModel model;

        public PlayMazeCommand(IModel model)
        {
            this.model = model;
        }

        public Result Execute(string[] args, TcpClient client = null)
        {
            Enum.TryParse(args[0], out Direction direction);

            MazeGame game = model.Players[client];
            Position currentPos = game.Players[client];
            Position pos = new Position(currentPos.Row, currentPos.Col);

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

                //notify other player about pos change
                foreach (TcpClient c in game.Players.Keys)
                {
                    if (c != client)
                        model.Controller.Send(json, c);
                }
            }

            return new Result(Status.Keep, "");
        }
    }
}
