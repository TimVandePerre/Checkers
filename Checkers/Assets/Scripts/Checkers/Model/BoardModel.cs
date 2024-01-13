using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Checkers.Model
{
    public class BoardModel
    {
        public event EventHandler<PieceEventArgs> PieceSpawned;
        public int Row { get; }
        public int Column { get; }

        public Dictionary<GridPos,TileModel> Tiles = new Dictionary<GridPos,TileModel>();
        public Dictionary<GridPos, PieceModel> Pieces = new Dictionary<GridPos, PieceModel>();

        public BoardModel(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public TileModel AddTile(GridPos pos)
        {
            TileModel tile = new TileModel(pos);
            tile.PositionClicked += Tile_PositionClicked;

            Tiles.Add(pos, tile);

            return tile;
        }

        public TileModel GetTileOnPos(GridPos pos)
        {
            TileModel tile = Tiles.GetValueOrDefault(pos);
            return tile;
        }

        public PieceModel AddPiece(GridPos pos, PieceColor pieceColor, PieceType pieceType)
        {
            PieceModel piece = new PieceModel(pos, pieceColor, pieceType);
            //TODO: sub to all events.

            PieceSpawned?.Invoke(this, new PieceEventArgs(piece));
            Pieces.Add(pos, piece);
            return piece;
        }

        public PieceModel GetPieceOnPos(GridPos pos)
        {
            PieceModel piece = Pieces.GetValueOrDefault(pos);
            return piece;
        }

        private void Tile_PositionClicked(object sender, System.EventArgs e)
        {
            //TODO: add logic for when Tile is clicked.
            //Temp
            TileModel tile = (TileModel)sender;
            tile.Color = TileColor.Highlight;
        }
    }
}
