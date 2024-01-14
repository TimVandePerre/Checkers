using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Checkers.Model
{
    public class BoardModel
    {
        public event EventHandler<PieceEventArgs> PieceSpawned;
        public event EventHandler<PieceEventArgs> PieceRemoved;
        public event EventHandler<PositionEventArgs> PositionClicked;


        public int Row { get; }
        public int Column { get; }

        public Dictionary<GridPos,TileModel> Tiles = new();
        public Dictionary<GridPos, PieceModel> Pieces = new();

        public BoardModel(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public TileModel AddTile(GridPos pos)
        {
            TileModel tile = new (pos, this);

            Tiles.Add(pos, tile);

            return tile;
        }

        public TileModel GetTileOnPos(GridPos pos)
        {
            TileModel tile = Tiles.GetValueOrDefault(pos);
            return tile;
        }

        public void TileClicked(GridPos pos)
        {
            PositionClicked?.Invoke(this, new PositionEventArgs(pos));
        }

        public void HighlightTile(GridPos pos, bool Highlight)
        {
            TileModel tile = GetTileOnPos(pos);
            tile.Highlight = Highlight;
        }

        public PieceModel AddPiece(GridPos pos, PieceColor pieceColor, PieceType pieceType)
        {
            PieceModel piece = new (pos, pieceColor, pieceType, this);

            PieceSpawned?.Invoke(this, new PieceEventArgs(piece));
            Pieces.Add(pos, piece);
            return piece;
        }

        public void RemovePiece(GridPos pos)
        {
            PieceModel piece = GetPieceOnPos(pos);
            Pieces.Remove(pos);
            piece.RemovePiece();
        }
        public PieceModel GetPieceOnPos(GridPos pos)
        {
            PieceModel piece = Pieces.GetValueOrDefault(pos);
            return piece;
        }

        public void HighlightPiece (GridPos pos, bool Highlight)
        {
            PieceModel piece = GetPieceOnPos(pos);
            piece.PieceColorHighlight = Highlight;
        }

        public void UpgradePiece (GridPos pos, PieceType type)
        {
            PieceModel piece = GetPieceOnPos(pos);
            piece.PieceType = type;
        }

        public void MovePieceToPos(PieceModel piece, GridPos destinationPos)
        {
            Pieces.Remove(piece.GridPosition);
            piece.GridPosition = destinationPos;
            Pieces.Add(destinationPos, piece);
        }
    }
}
