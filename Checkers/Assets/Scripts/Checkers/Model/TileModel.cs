using System;

namespace Checkers.Model
{
    public class TileModel
    {
        public event EventHandler<EventArgs> PositionClicked;
        public event EventHandler<ColorEventArgs> ColorChanged;
        public TileColor Color 
        { 
            get => _color;
            set
            {
                if(value != _color)
                {
                    _color = value;
                    ColorChanged?.Invoke(this, new ColorEventArgs(value));
                }
            }
        }

        public GridPos Pos { get; }

        private TileColor _color;

        public TileModel(GridPos pos)
        {
            Pos = pos;
        }

        public void TileClicked()
        {
            PositionClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
