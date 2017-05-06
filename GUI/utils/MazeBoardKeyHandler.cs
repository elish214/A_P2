using GUI.controls;
using MazeLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GUI.utils
{
    public class MazeBoardKeyHandler
    {
        private MazeBoard board;

        public MazeBoardKeyHandler(MazeBoard board)
        {
            this.board = board;
        }

        public void KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.Key)
            {
                case Key.Up:
                    board.Move(Direction.Up);
                    break;

                case Key.Down:
                    board.Move(Direction.Down);
                    break;

                case Key.Left:
                    board.Move(Direction.Left);
                    break;

                case Key.Right:
                    board.Move(Direction.Right);
                    break;
            }
        }
    }
}
