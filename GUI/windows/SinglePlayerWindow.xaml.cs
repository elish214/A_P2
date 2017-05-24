using GUI.controls;
using GUI.model;
using GUI.utils;
using GUI.viewmodels;
using MazeLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GUI.windows
{
    /// <summary>
    /// Interaction logic for SinglePlayerWindow.xaml
    /// </summary>
    public partial class SinglePlayerWindow : Window
    {
        /// <summary>
        /// private view model member.
        /// </summary>
        private SinglePlayerViewModel vm;

        /// <summary>
        /// Constructor.
        /// </summary>
        public SinglePlayerWindow()
        {
            InitializeComponent();
            vm = new SinglePlayerViewModel(new SinglePlayerModel());
            DataContext = vm;

            vm.PropertyChanged +=
                delegate (Object sender, PropertyChangedEventArgs e)
                {
                    if (e.PropertyName == "Solution")
                    {
                        SolveMaze(vm.GetSolution());
                    }
                };
            KeyDown += new KeyEventHandler(new MazeBoardKeyHandler(mzbMaze).KeyDown);
            mzbMaze.Win += new YouWinMsg().YouWin;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="maze"> a maze. </param>
        public SinglePlayerWindow(Maze maze) : this()
        {
            mzbMaze.Maze = maze;
            vm.Model.Maze = maze;
            Title = maze.Name;
        }

        /// <summary>
        /// solvin maze a synchronic
        /// </summary>
        /// <param name="sol"> a solution. </param>
        private async void SolveMaze(String sol)
        {
            mzbMaze.Restart();
            for (int i = 0; i < sol.Length; i++)
            {
                await Task.Delay(100);
                mzbMaze.Move((Direction)Char.GetNumericValue(sol[i]));
            }
        }

        /// <summary>
        /// click on main menu button.
        /// </summary>
        /// <param name="sender"> a sender. </param>
        /// <param name="e"> an event. </param>
        private void mainMenu_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            Close();
        }

        /// <summary>
        /// click on solve button.
        /// </summary>
        /// <param name="sender"> a sender. </param>
        /// <param name="e"> an event. </param>
        private void solve_Click(object sender, RoutedEventArgs e)
        {
            vm.Solve();
        }

        /// <summary>
        /// click on restart button.
        /// </summary>
        /// <param name="sender"> a sender. </param>
        /// <param name="e"> an event. </param>
        private void restartGame_Click(object sender, RoutedEventArgs e)
        {
            mzbMaze.Restart();
        }
    }
}
