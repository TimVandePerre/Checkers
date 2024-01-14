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

        private PieceColor _currentPlayerColor;
        private PieceModel _selectedPiece;
        private List<TileModel> _validTiles = new List<TileModel>();

        public CheckersEngine(BoardModel board, PieceColor startingPlayer)
        {
            _board = board;
            _board.PositionClicked += Board_PositionClicked;
            _currentPlayerColor = startingPlayer;


            InitializeBoard();
        }

        private void Board_PositionClicked(object sender, PositionEventArgs e)
        {
            PieceModel piece = _board.GetPieceOnPos(e.GridPos);
            TileModel tile = _board.GetTileOnPos(e.GridPos);

            if (piece == null)
            {
                if (_validTiles.Contains(tile))
                {
                    MovePiece(tile.Pos);
                    ResetBoardHighlights();
                    SwitchPlayer();
                }
                else ResetBoardHighlights();
            }

            else
            {
                if (piece != _selectedPiece)
                {
                    if (piece.PieceColor != _currentPlayerColor) return;
                    ResetBoardHighlights();
                    _selectedPiece = piece;
                    _board.HighlightPiece(e.GridPos, true);
                    GetValidTiles();
                }
            }
        }

        private void ResetBoardHighlights()
        {
            foreach (TileModel tile in _board.Tiles.Values)
            {
                _board.HighlightTile(tile.Pos, false);
            }
            foreach (PieceModel pieces in _board.Pieces.Values)
            {
                _board.HighlightPiece(pieces.GridPosition, false);
            }

            _validTiles.Clear();

            _selectedPiece = null;
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

        private void GetValidTiles()
        {
            MovementHelper movement = new (_selectedPiece, _board);
            _validTiles = movement.GetValidTiles();

            foreach (TileModel tile in _validTiles)
            {
                _board.HighlightTile(tile.Pos, true);
            }
        }

        private void MovePiece(GridPos destination)
        {
            _board.MovePieceToPos(_selectedPiece, destination);
        }

        private void SwitchPlayer()
        {
            switch(_currentPlayerColor)
            {
                case PieceColor.Dark:
                    _currentPlayerColor = PieceColor.Light; break;
                case PieceColor.Light:
                    _currentPlayerColor = PieceColor.Dark; break;
            }
        }
    }
}
