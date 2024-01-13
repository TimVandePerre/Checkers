using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Checkers.Model
{
    public class PieceModel
    {
        public event EventHandler<PieceHighlightEventArgs> PieceHighlightChanged;

        public PieceColor PieceColor { get; private set; }

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

        public bool PieceColorHighlight
        { 
            get => _pieceColorHighlight;
            set
            {
                if (_pieceColorHighlight != value)
                {
                    _pieceColorHighlight = value;
                    PieceHighlightChanged?.Invoke(this, new PieceHighlightEventArgs(value));
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
        private bool _pieceColorHighlight;
        private PieceType _pieceType;

        public PieceModel(GridPos gridPosition, PieceColor pieceColor, PieceType type)
        {
            _gridPos = gridPosition;
            PieceColor = pieceColor;
            _pieceType = type;
        }
    }
}
