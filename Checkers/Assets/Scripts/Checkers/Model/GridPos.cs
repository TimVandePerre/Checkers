using JetBrains.Annotations;
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

        public static GridPos operator * (GridPos lhs, int scalar)
        {
            GridPos result = new GridPos();
            result.X = lhs.X * scalar;
            result.Y = lhs.Y * scalar;
            return result;
        }

        public static GridPos operator + (GridPos lhs, GridPos rhs)
        {
            GridPos result = new GridPos();
            result.X = lhs.X + rhs.X;
            result.Y = lhs.Y + rhs.Y;
            return result;
        }

        public static GridPos operator - (GridPos lhs, GridPos rhs)
        {
            GridPos result = new GridPos();
            result.X = lhs.X - rhs.X;
            result.Y = lhs.Y - rhs.Y;
            return result;
        }
    }
}
