using System.Collections.Generic;

namespace Checkers.Model.Engine
{
    public class MovementHelper
    {
        private readonly PieceModel _piece;
        private readonly BoardModel _board;

        public MovementHelper(PieceModel piece, BoardModel board)
        {
            _piece = piece;
            _board = board;
        }

        public List<TileModel> GetValidTiles()
        { 
            return new MovementProvider(_piece.GridPosition, _piece.PieceType, _board).AddMovement();
        }
    }
}
