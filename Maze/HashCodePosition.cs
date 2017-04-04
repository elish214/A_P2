using MazeLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    public class HashCodePosition
    {
        private Position pos;

        public HashCodePosition(Position pos)
        {
            this.pos = pos;
        }

        public int Row()
        {
            return pos.Row;
        }

        public int Col()
        {
            return pos.Col;
        }

        public bool Equals(HashCodePosition s) // we overload Object's Equals method
        {
            return Row() == s.Row() && Col() == s.Col();
        }

        public override int GetHashCode()
        {
            int result = Row();
            result = 31 * result + Col();
            return result;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as HashCodePosition);
        }
    }
}
