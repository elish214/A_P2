using MazeLib;
using SearchAlgorithmsLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeComp
{
    public class SearchableMaze : ISearchable<Position>
    {
        public Maze Maze { get; set; }

        public SearchableMaze(Maze maze)
        {
            Maze = maze;
        }

        public State<Position> GetInitialState()
        {
            Console.Write($"({Maze.InitialPos.Row}, {Maze.InitialPos.Col})");
            return State<Position>.StatePool.GetState(Maze.InitialPos);
        }

        public State<Position> GetGoalState()
        {
            Console.Write($"({Maze.GoalPos.Row}, {Maze.GoalPos.Col})");
            return State<Position>.StatePool.GetState(Maze.GoalPos);
        }

        public List<State<Position>> GetAllPossibleStates(State<Position> s)
        {
            List<State<Position>> states = new List<State<Position>>();
            int row = s.TState.Row;
            int col = s.TState.Col;

            if (row > 0 && Maze[row - 1, col] != CellType.Wall)
            {
                Console.Write($"({row - 1}, {col})");
                states.Add(State<Position>.StatePool.GetState(new Position(row - 1, col)));
            }

            if (col > 0 && Maze[row, col - 1] != CellType.Wall)
            {
                Console.Write($"({row}, {col - 1})");
                states.Add(State<Position>.StatePool.GetState(new Position(row, col - 1)));
            }

            if (row < Maze.Rows - 1 && Maze[row + 1, col] != CellType.Wall)
            {
                Console.Write($"({row + 1}, {col})");
                states.Add(State<Position>.StatePool.GetState(new Position(row + 1, col)));
            }

            if (col < Maze.Cols - 1 && Maze[row, col + 1] != CellType.Wall)
            {
                Console.Write($"({row}, {col + 1})");
                states.Add(State<Position>.StatePool.GetState(new Position(row, col + 1)));
            }

            return states;
        }
    }
}
