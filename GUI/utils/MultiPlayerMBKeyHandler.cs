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
    /// <summary>
    /// multi player maze board key handler class.
    /// </summary>
    class MultiPlayerMBKeyHandler
    {
        /// <summary>
        /// private maze board member.
        /// </summary>
        private MazeBoard board;

        /// <summary>
        /// private ViewModel member.
        /// </summary>
        private MultiPlayerViewModel vm;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="board"> a maze board. </param>
        /// <param name="vm"> a ViewModel. </param>
        public MultiPlayerMBKeyHandler(MazeBoard board, MultiPlayerViewModel vm)
        {
            this.board = board;
            this.vm = vm;
        }

        /// <summary>
        /// wey down method.
        /// </summary>
        /// <param name="sender"> the sender. </param>
        /// <param name="e"> an event. </param>
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
