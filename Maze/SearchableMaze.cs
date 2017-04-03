using MazeLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearchAlgorithmsLib;

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
            return new State<Position>(Maze.InitialPos);
        }

        public State<Position> GetGoalState()
        {
            return new State<Position>(Maze.GoalPos);
        }

        public List<State<Position>> GetAllPossibleStates(State<Position> s)
        {
            List<State<Position>> states = new List<State<Position>>();
            int row = s.TState.Row;
            int col = s.TState.Col;

            if(row > 0 && Maze[row - 1, col] != CellType.Wall)
            {
                states.Add(new State<Position>(new Position(row - 1, col), s, s.Cost + 1));
            }

            if (col > 0 && Maze[row, col - 1] != CellType.Wall)
            {
                states.Add(new State<Position>(new Position(row, col - 1), s, s.Cost + 1));
            }

            if (row < Maze.Rows - 1 && Maze[row + 1, col] != CellType.Wall)
            {
                states.Add(new State<Position>(new Position(row + 1, col), s, s.Cost + 1));
            }

            if (col < Maze.Cols - 1 && Maze[row, col + 1] != CellType.Wall)
            {
                states.Add(new State<Position>(new Position(row, col + 1), s, s.Cost + 1));
            }

            return states;
        }
    }
}
