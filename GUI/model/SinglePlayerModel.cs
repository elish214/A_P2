using Client;
using GUI.utils;
using MazeComp;
using MazeLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.model
{
    /// <summary>
    /// single player model class.
    /// </summary>
    class SinglePlayerModel : Model, ISinglePlayerModel
    {
        /// <summary>
        /// private maze member.
        /// </summary>
        private Maze maze;

        /// <summary>
        /// public maze Dependency object.
        /// </summary>
        public Maze Maze
        {
            get { return maze; }
            set
            {
                maze = value;
                NotifyPropertyChanged("Maze");
            }
        }

        /// <summary>
        /// private maze solution member.
        /// </summary>
        private MazeSolution solution;

        /// <summary>
        /// public maze solution dependency object.
        /// </summary>
        public MazeSolution Solution
        {
            get
            {
                return solution;
            }
            set
            {
                solution = value;
                NotifyPropertyChanged("Solution");
            }
        }

        /// <summary>
        /// solving method.
        /// </summary>
        public void Solve()
        {
            string result = client.Client.Instance.WriteRead($"solve {maze.Name} {Properties.Settings.Default.SearchAlgorithm}");

            Solution = MazeSolution.FromJSON(result);
        }
    }
}
