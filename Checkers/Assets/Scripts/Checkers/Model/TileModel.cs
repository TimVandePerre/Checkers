using System;

namespace Checkers.Model
{
    public class TileModel
    {
        public event EventHandler<TileColorEventArgs> ColorChanged;
        public bool Highlight 
        { 
            get => _highlight;
            set
            {
                if(value != _highlight)
                {
                    _highlight = value;
                    ColorChanged?.Invoke(this, new TileColorEventArgs(value));
                }
            }
        }

        public GridPos Pos { get; }

        private bool _highlight;
        private readonly BoardModel _board;

        public TileModel(GridPos pos, BoardModel board)
        {
            Pos = pos;
            _board = board;
        }

        public void TileClicked()
        {
            _board.TileClicked(Pos);
        }
    }
}
