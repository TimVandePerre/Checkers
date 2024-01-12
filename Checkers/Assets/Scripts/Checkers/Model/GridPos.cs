using System.Collections;
using System.Collections.Generic;

namespace Checkers.Model
{
    public struct GridPos
    {
        public int X { get; set; } 
        public int Y { get; set; }

        public GridPos(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
