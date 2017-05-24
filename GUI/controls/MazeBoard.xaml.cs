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
        /// <summary>
        /// public maze dependency object.
        /// </summary>
        public Maze Maze
        {
            get { return (Maze)GetValue(MazeProperty); }
            set { SetValue(MazeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Maze.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MazeProperty =
            DependencyProperty.Register("Maze", typeof(Maze), typeof(MazeBoard), new UIPropertyMetadata(mazeChanged));

        /// <summary>
        /// public player position dependency object.
        /// </summary>
        public Position PlayerPos
        {
            get { return playerPos; }
            set
            {
                playerPos = value;
                DrawPlayer();
            }
        }

        /// <summary>
        /// private position member.
        /// </summary>
        private Position playerPos;

        /// <summary>
        /// a moving delegate.
        /// </summary>
        /// <param name="pos"> a position. </param>
        /// <param name="d"> a direction. </param>
        public delegate void PlayerMoved(Position pos, Direction d);

        /// <summary>
        /// a moving event.
        /// </summary>
        public event PlayerMoved Moved;

        /// <summary>
        /// a winning delegate.
        /// </summary>
        public delegate void PlayerWin();

        /// <summary>
        /// a winning event.
        /// </summary>
        public event PlayerWin Win;

        /// <summary>
        /// width member.
        /// </summary>
        private int width;

        /// <summary>
        /// height member.
        /// </summary>
        private int height;

        /// <summary>
        /// Constructor.
        /// </summary>
        public MazeBoard()
        {
            InitializeComponent();
        }

        /// <summary>
        /// update maze when changed.
        /// </summary>
        /// <param name="d"> the dependency object. </param>
        /// <param name="e"> an event. </param>
        private static void mazeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MazeBoard board = (MazeBoard)d;
            board.DrawMaze();
        }

        /// <summary>
        /// Draw the maze.
        /// </summary>
        private void DrawMaze()
        {
            height = 300 / Maze.Rows;
            width = 300 / Maze.Cols;

            Rectangle[,] grid = new Rectangle[Maze.Rows, Maze.Cols];

            for (int i = 0; i < Maze.Rows; i++)
            {
                for (int j = 0; j < Maze.Cols; j++)
                {
                    grid[i, j] = new Rectangle()
                    {
                        Height = height,
                        Width = width
                    };
                    MazeCanvas.Children.Add(grid[i, j]);
                    Panel.SetZIndex(grid[i, j], 0);
                    Canvas.SetLeft(grid[i, j], j * width);
                    Canvas.SetTop(grid[i, j], i * height);
                }
            }

            string str = Maze.ToString();
            string s = "";
            foreach (char c in str)
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
                            grid[k, t].Fill = Brushes.White;
                            break;
                        case '1':
                            grid[k, t].Fill = Brushes.Black;
                            break;
                        case '#':
                            grid[k, t].Fill = Brushes.Red;//end
                            break;
                        case '*':
                            grid[k, t].Fill = Brushes.White;//start
                            break;
                    }
                }
            }

            PlayerPos = Maze.InitialPos;
        }

        /// <summary>
        /// Draw player on board.
        /// </summary>
        public void DrawPlayer()
        {
            player.Height = height;
            player.Width = width;

            Canvas.SetTop(player, PlayerPos.Row * height);
            Canvas.SetLeft(player, PlayerPos.Col * width);
        }

        /// <summary>
        /// move a player on his board.
        /// </summary>
        /// <param name="d"> a direction to move to. </param>
        /// <returns> whether move is valid or not. </returns>
        public Boolean Move(Direction d)
        {
            Position pos = new Position(PlayerPos.Row, PlayerPos.Col);

            switch (d)
            {
                case Direction.Up:
                    pos.Row--;
                    break;

                case Direction.Down:
                    pos.Row++;
                    break;

                case Direction.Left:
                    pos.Col--;
                    break;

                case Direction.Right:
                    pos.Col++;
                    break;
            }

            if (0 <= pos.Row && 0 <= pos.Col &&
                pos.Row < Maze.Rows && pos.Col < Maze.Cols &&
                Maze[pos.Row, pos.Col] != CellType.Wall)
            {
                PlayerPos = pos;
                Moved?.Invoke(pos, d);
                if(pos.Row == Maze.GoalPos.Row && pos.Col == Maze.GoalPos.Col)
                {
                    Win?.Invoke();
                }
                return true;
            }

            return false;
        }

        /// <summary>
        /// Restart game.
        /// </summary>
        public void Restart()
        {
            PlayerPos = Maze.InitialPos;
        }
    }
}

