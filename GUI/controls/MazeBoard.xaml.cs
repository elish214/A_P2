using MazeGeneratorLib;
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
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace GUI.controls
{
    /// <summary>
    /// Interaction logic for MazeBoard.xaml
    /// </summary>
    public partial class MazeBoard : UserControl
    {
        public Maze Maze
        {
            get { return (Maze)GetValue(MazeProperty); }
            set { SetValue(MazeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Maze.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MazeProperty =
            DependencyProperty.Register("Maze", typeof(Maze), typeof(MazeBoard), new UIPropertyMetadata(mazeChanged));

        private static void mazeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MazeBoard board = (MazeBoard)d;
            board.DrawMaze();
        }

        private void DrawMaze()
        {
            Label[,] grid = new Label[Maze.Rows, Maze.Cols];

            for (int i = 0; i < Maze.Rows; i++)
            {
                for (int j = 0; j < Maze.Cols; j++)
                {
                    grid[i, j] = new Label();
                    Grid.SetRow(grid[i, j], i);
                    Grid.SetColumn(grid[i, j], j);
                    mazeGrid.Children.Add(grid[i, j]);
                }
            }

            string s = Maze.ToString();

            for (int i = 0; i < Maze.Rows; i++)
            {
                for (int j = 0; j < Maze.Cols; j++)
                {

                    int num = Maze.Rows * Maze.Cols + j;
                    switch (s[num])
                    {
                        case '0':
                            grid[i, j].Background = Brushes.White;
                            break;
                        case '1':
                            grid[i, j].Background = Brushes.Black;
                            break;
                        case '#':
                            grid[i, j].Background = Brushes.Blue;//end
                            break;
                        case '*':
                            grid[i, j].Background = Brushes.Red;//start
                            break;
                    }
                }
            }
        }

        public MazeBoard()
        {
        }

        public MazeBoard(Maze maze)
        {
            InitializeComponent();

            Maze = maze;

            for (int i = 0; i < maze.Cols; i++)
            {
                mazeGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }

            for (int i = 0; i < maze.Cols; i++)
            {
                mazeGrid.RowDefinitions.Add(new RowDefinition());
            }
        }

        //public function for any move.

    }
}
