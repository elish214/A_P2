using GUI.model;
using GUI.utils;
using GUI.viewmodels;
using MazeLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Interaction logic for MultiPlayerWindow.xaml
    /// </summary>
    public partial class MultiPlayerWindow : Window
    {
        private MultiPlayerViewModel vm;

        public MultiPlayerWindow()
        {
            InitializeComponent();
            vm = new MultiPlayerViewModel(new MultiPlayerModel());
            DataContext = vm;

            KeyDown += new KeyEventHandler(new MultiPlayerMBKeyHandler(myBoard, vm).KeyDown);
            //add somehow vm.Moved(string move);
            //KeyDown += new KeyEventHandler(); // to send my move, to get other's move.
            //KeyDown += new KeyEventHandler(new MazeBoardKeyHandler(otherBoard).KeyDown);

            myBoard.Win += new YouWinMsg().YouWin;
        }

        public MultiPlayerWindow(Maze maze) : this()
        {
            myBoard.Maze = maze;
            otherBoard.Maze = maze;
            vm.Model.Maze = maze;
            Title = maze.Name;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            vm.CloseGame();
            new MainWindow().Show();
            Close();
        }
    }
}
