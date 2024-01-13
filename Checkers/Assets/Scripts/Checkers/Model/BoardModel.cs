using System.Collections.Generic;

namespace Checkers.Model
{
    public class BoardModel
    {
        public int Row { get; }
        public int Column { get; }

        public Dictionary<GridPos,TileModel> Tile = new Dictionary<GridPos,TileModel>();

        public BoardModel(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public TileModel AddTile(GridPos pos)
        {
            TileModel tile = new TileModel(pos);
            tile.PositionClicked += Tile_PositionClicked;

            Tile.Add(pos, tile);

            return tile;
        }

        private void Tile_PositionClicked(object sender, System.EventArgs e)
        {
            TileModel tile = (TileModel)sender;
            tile.Color = TileColor.Highlight;
        }
    }
}
