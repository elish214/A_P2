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
    class SinglePlayerModel : Model, ISinglePlayerModel
    {
        private Maze maze;
        public Maze Maze
        {
            get { return maze; }
            set
            {
                maze = value;
                NotifyPropertyChanged("Maze");
            }
        }

        private MazeSolution solution;
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

        public void Solve()
        {
            string result = client.Client.Instance.WriteRead($"solve {maze.Name} {Properties.Settings.Default.SearchAlgorithm}");

            Solution = MazeSolution.FromJSON(result);
        }
    }
}
