using GUI.controls;
using GUI.viewmodels;
using MazeLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GUI.utils
{
    class MultiPlayerMBKeyHandler
    {
        private MazeBoard board;
        private MultiPlayerViewModel vm;

        public MultiPlayerMBKeyHandler(MazeBoard board, MultiPlayerViewModel vm)
        {
            this.board = board;
            this.vm = vm;
        }

        public void KeyDown(object sender, KeyEventArgs e)
        {
            vm.Moved(e.Key.ToString());

            switch (e.Key)
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
