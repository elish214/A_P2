using MazeLib;
using SearchAlgorithmsLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeComp
{
    /// <summary>
    /// Searchable Maze class. adapter for a simple maze.
    /// </summary>
    public class SearchableMaze : ISearchable<Position>
    {
        /// <summary>
        /// Holds a simple maze object.
        /// </summary>
        public Maze Maze { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="maze"> a simple maze object. </param>
        public SearchableMaze(Maze maze)
        {
            Maze = maze;
        }

        /// <summary>
        /// Returns maze's initial state.
        /// </summary>
        /// <returns> maze's initial state. </returns>
        public State<Position> GetInitialState()
        {
            //Console.Write($"({Maze.InitialPos.Row}, {Maze.InitialPos.Col})");
            return State<Position>.StatePool.GetState(Maze.InitialPos);
        }

        /// <summary>
        /// Returns maze's goal state.
        /// </summary>
        /// <returns> maze's goal state. </returns>
        public State<Position> GetGoalState()
        {
            //Console.Write($"({Maze.GoalPos.Row}, {Maze.GoalPos.Col})");
            return State<Position>.StatePool.GetState(Maze.GoalPos);
        }

        /// <summary>
        /// Returns a list of all possible states from specific state.
        /// </summary>
        /// <param name="s"> a specific state. </param>
        /// <returns> a list of all possible states from specific state. </returns>
        public List<State<Position>> GetAllPossibleStates(State<Position> s)
        {
            List<State<Position>> states = new List<State<Position>>();
            int row = s.TState.Row;
            int col = s.TState.Col;

            if (row > 0 && Maze[row - 1, col] != CellType.Wall)
            {
                //Console.Write($"({row - 1}, {col})");
                states.Add(State<Position>.StatePool.GetState(new Position(row - 1, col)));
            }

            if (col > 0 && Maze[row, col - 1] != CellType.Wall)
            {
                //Console.Write($"({row}, {col - 1})");
                states.Add(State<Position>.StatePool.GetState(new Position(row, col - 1)));
            }

            if (row < Maze.Rows - 1 && Maze[row + 1, col] != CellType.Wall)
            {
                //Console.Write($"({row + 1}, {col})");
                states.Add(State<Position>.StatePool.GetState(new Position(row + 1, col)));
            }

            if (col < Maze.Cols - 1 && Maze[row, col + 1] != CellType.Wall)
            {
                //Console.Write($"({row}, {col + 1})");
                states.Add(State<Position>.StatePool.GetState(new Position(row, col + 1)));
            }

            return states;
        }
    }
}
