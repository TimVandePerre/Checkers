using System;

namespace Checkers.Model
{
    public class ColorEventArgs : EventArgs
    {
        public TileColor Color { get; }

        public ColorEventArgs(TileColor color)
        {
            Color = color;
        }
    }
}
