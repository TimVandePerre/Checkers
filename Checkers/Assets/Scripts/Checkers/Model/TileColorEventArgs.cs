using System;

namespace Checkers.Model
{
    public class TileModelEventArgs : EventArgs
    {
        public TileModel TileModel { get; }
        public TileModelEventArgs(TileModel model)
        {
            TileModel = model;
        }
    }

    public class TileColorEventArgs : EventArgs
    {
        public bool Color { get; }

        public TileColorEventArgs( bool color)
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

    public class PieceColorEventArgs : EventArgs
    {
        public bool PieceColor { get; }
        public PieceColorEventArgs(bool Highlight)
        {
            PieceColor = Highlight;
        }
    }

    public class PositionEventArgs : EventArgs
    {
        public GridPos GridPos { get; }
        public PositionEventArgs(GridPos pos)
        {
            GridPos = pos;
        }
    }
}
