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

    public class PieceEventArgs : EventArgs
    {
        public PieceModel Piece { get; }

        public PieceEventArgs(PieceModel model)
        {
            Piece = model;   
        }
    }
}
