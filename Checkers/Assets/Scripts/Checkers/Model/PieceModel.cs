using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Checkers.Model
{
    public class PieceModel
    {
        public GridPos GridPosition 
        {
            get => _gridPos;
            set
            {
                if(!_gridPos.Equals(value))
                {
                    _gridPos = value;
                    //TODO: shoot event when position is changed.
                }
            }
        }

        public PieceColor PieceColor 
        { 
            get => _pieceColor;
            set
            {
                if (!_pieceColor.Equals(value))
                {
                    _pieceColor = value;
                    //TODO: shoot event when colour is changed.
                }
            }
        }

        public PieceType PieceType 
        {
            get => _pieceType;
            set
            {
                if(_pieceType != value)
                {
                    _pieceType = value;
                    //TODO: shoot event when type is changed.
                }
            }
        }

        private GridPos _gridPos;
        private PieceColor _pieceColor;
        private PieceType _pieceType;

        public PieceModel(GridPos gridPosition, PieceColor pieceColor, PieceType type)
        {
            _gridPos = gridPosition;
            _pieceColor = pieceColor;
            _pieceType = type;
        }
    }
}
