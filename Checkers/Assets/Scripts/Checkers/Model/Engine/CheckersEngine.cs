using Checkers.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Checkers.Model.Engine
{
    public class CheckersEngine
    {
        private readonly BoardModel _board;

        private PieceColor _CurrentPlayerColor;
        private PieceModel _selectedPiece;

        public CheckersEngine(BoardModel board, PieceColor startingPlayer)
        {
            _board = board;
            _board.PositionClicked += _board_PositionClicked;
            _CurrentPlayerColor = startingPlayer;


            InitializeBoard();
        }

        private void _board_PositionClicked(object sender, PositionEventArgs e)
        {
            foreach(PieceModel pieces in _board.Pieces.Values)
            {
                _board.HighlightPiece(pieces.GridPosition, false);
            }

            _selectedPiece = null;

            PieceModel piece = _board.GetPieceOnPos(e.GridPos);

            if (piece == null) return;

            _selectedPiece = piece;

            _board.HighlightPiece(e.GridPos, true);

        }

        private void InitializeBoard()
        {
            //TODO: add tiles based on board sizes.

            for(int i = 0; i < 3; i++)
            {
                for (int j = 0; j < _board.Column; j++)
                {
                    if ((i + j) % 2 == 0) _board.AddPiece(new GridPos(i, j), PieceColor.Dark, PieceType.Pawn);
                }
            }

            for(int i = _board.Row - 3; i < _board.Row; i++)
            {
                for(int j= 0;  j < _board.Column; j++)
                {
                    if((i + j) % 2 == 0) _board.AddPiece(new GridPos(i,j), PieceColor.Light, PieceType.Pawn);
                }
            }
        }
    }
}
