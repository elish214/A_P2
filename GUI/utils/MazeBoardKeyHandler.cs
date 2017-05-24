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
    /// <summary>
    /// maze board key handler class.
    /// </summary>
    public class MazeBoardKeyHandler
    {
        /// <summary>
        /// private maze board member.
        /// </summary>
        private MazeBoard board;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="board"> a maze board. </param>
        public MazeBoardKeyHandler(MazeBoard board)
        {
            this.board = board;
        }

        /// <summary>
        /// a key down method.
        /// </summary>
        /// <param name="sender"> the sender. </param>
        /// <param name="e"> an event. </param>
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
