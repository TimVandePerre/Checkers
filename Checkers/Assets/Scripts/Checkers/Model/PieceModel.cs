using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Checkers.Model
{
    public class PieceModel
    {
        public event EventHandler<PositionEventArgs> PositionChanged;
        public event EventHandler<PieceColorEventArgs> PieceColorChanged;
        public event EventHandler<EventArgs> PieceUpgrade;
        public event EventHandler<EventArgs> PieceRemoved;
        public GridPos GridPosition 
        {
            get => _gridPos;
            set
            {
                if(!_gridPos.Equals(value))
                {
                    _gridPos = value;
                    PositionChanged?.Invoke(this, new PositionEventArgs(value));
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
                    PieceColorChanged?.Invoke(this, new PieceColorEventArgs(value));
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
                    PieceUpgrade?.Invoke(this, new EventArgs());
                }
            }
        }

        public PieceColor PieceColor { get; private set; }
        public readonly BoardModel _board;

        private GridPos _gridPos;
        private bool _pieceColorHighlight;
        private PieceType _pieceType;

        public PieceModel(GridPos gridPosition, PieceColor pieceColor, PieceType type, BoardModel board)
        {
            _gridPos = gridPosition;
            PieceColor = pieceColor;
            _pieceType = type;
            _board = board;
        }

        public void RemovePiece()
        {
            PieceRemoved?.Invoke(this, new EventArgs());
        }
    }
}
