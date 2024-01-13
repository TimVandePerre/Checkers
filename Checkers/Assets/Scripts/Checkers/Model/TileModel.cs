using System;

namespace Checkers.Model
{
    public class TileModel
    {
        public event EventHandler<TileColorEventArgs> ColorChanged;
        public TileColor Color 
        { 
            get => _color;
            set
            {
                if(value != _color)
                {
                    _color = value;
                    ColorChanged?.Invoke(this, new TileColorEventArgs(value));
                }
            }
        }

        public GridPos Pos { get; }

        private TileColor _color;
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
