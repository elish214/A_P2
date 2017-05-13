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
        private SinglePlayerViewModel vm;

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

        public SinglePlayerWindow(Maze maze) : this()
        {
            mzbMaze.Maze = maze;
            vm.Model.Maze = maze;
            Title = maze.Name;
        }

        private async void SolveMaze(String sol)
        {
            mzbMaze.Restart();
            for (int i = 0; i < sol.Length; i++)
            {
                await Task.Delay(100);
                mzbMaze.Move((Direction)Char.GetNumericValue(sol[i]));
            }
        }

        private void mainMenu_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            Close();
        }

        private void solve_Click(object sender, RoutedEventArgs e)
        {
            vm.Solve();
        }

        private void restartGame_Click(object sender, RoutedEventArgs e)
        {
            mzbMaze.Restart();
        }
    }
}
