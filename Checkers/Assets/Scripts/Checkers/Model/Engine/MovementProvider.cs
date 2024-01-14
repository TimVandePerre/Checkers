using System;
using System.Collections.Generic;

namespace Checkers.Model.Engine
{
    public class MovementProvider
    {
        private readonly GridPos _startingPos;
        private readonly PieceType _pieceType;
        private readonly BoardModel _board;

        private List<GridPos> _pawnDirections;
        private List<GridPos> _kingDirections;
        public MovementProvider(GridPos startingPos, PieceType pieceType, BoardModel board)
        {
            _startingPos = startingPos;
            _pieceType = pieceType;
            _board = board;

            _pawnDirections = new List<GridPos>
            {
                new GridPos(1,-1),
                new GridPos(1,1)
            };
        }

        public List<TileModel> AddMovement()
        {
            List<TileModel> tiles = new List<TileModel>();
            switch(_pieceType)
            {
                case PieceType.Pawn:
                    tiles = GetPawnTiles();
                    break;
                case PieceType.King:
                    tiles = GetKingTiles();
                    break;
            }

            return tiles;
        }

        private List<TileModel> GetPawnTiles()
        {
            List<TileModel> tiles = new List<TileModel>();
            PieceModel piece = _board.GetPieceOnPos(_startingPos);

            foreach(GridPos gridPos in _pawnDirections)
            {
                GridPos tileOffset = gridPos;

                if(piece.PieceColor == PieceColor.Light)  tileOffset.X *= -1;

                GridPos gridposOffset = _startingPos + tileOffset;
                TileModel offsetTile = _board.GetTileOnPos(gridposOffset);
                PieceModel pieceOffset = _board.GetPieceOnPos(gridposOffset);

                if (offsetTile == null) continue;

                else if (pieceOffset == null)
                {
                    tiles.Add(offsetTile);
                }
            }

            return tiles;
        }

        private List<TileModel> GetKingTiles()
        {
            throw new NotImplementedException();
        }
    }
}
