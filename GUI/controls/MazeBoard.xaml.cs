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

        //add dependency property for position.

        private void DrawMaze()
        {
            Rectangle[,] grid = new Rectangle[Maze.Rows, Maze.Cols];

            for (int i = 0; i < Maze.Rows; i++)
            {
                for (int j = 0; j < Maze.Cols; j++)
                {
                    grid[i, j] = new Rectangle();
                    grid[i, j].Height = 20;
                    grid[i, j].Width = 20;
                    MazeCanvas.Children.Add(grid[i, j]);
                    Canvas.SetLeft(grid[i, j], j*20);
                    Canvas.SetTop(grid[i, j], i*20);
                }
            }

            string str = Maze.ToString();
            string s = "";
            foreach(char c in str)
            {
                if (c != '\r' && c != '\n')
                    s += c;
            }
            Console.WriteLine(s);

            for (int k = 0; k < Maze.Rows; k++)
            {
                for (int t = 0; t < Maze.Cols; t++)
                {

                    int num = k * Maze.Cols + t;
                    switch (s[num])
                    {
                        case '0':
                            grid[k, t].Fill = Brushes.Pink;
                            break;
                        case '1':
                            grid[k, t].Fill = Brushes.Black;
                            break;
                        case '#':
                            grid[k, t].Fill = Brushes.Blue;//end
                            break;
                        case '*':
                            grid[k, t].Fill = Brushes.Red;//start
                            break;
                    }
                }
            }
        }

        public MazeBoard()
        {
            InitializeComponent();

            ///need to get a maze from someone.
            ///Maze = 
            Maze = new DFSMazeGenerator().Generate(8, 8);

        }

        //4 public function for any move.

    }
}

