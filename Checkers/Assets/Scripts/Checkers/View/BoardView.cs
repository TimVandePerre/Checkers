using Checkers.Model;
using System;
using UnityEngine;

namespace Checkers.View
{
    public class BoardView : MonoBehaviour
    {
        public int _rows;
        public int _columns;
        public BoardModel _boardModel { get; private set; }

        [SerializeField] GameObject _pawnPiece;

        private void Awake()
        {
            _rows = gameObject.GetComponent<Board_Builder>().Rows;
            _columns = gameObject.GetComponent<Board_Builder>().Columns;

            CreateBoardModel();
            SetBoardTiles();
            SetBoardPieces();
        }

        public void CreateBoardModel()
        {
            _boardModel = new BoardModel(_rows, _columns);
        }

        private void SetBoardTiles()
        {
            TileView[] tileViews = GetComponentsInChildren<TileView>();

            foreach (TileView tileView in tileViews)
            {
                GridPos gridPos = PositionHelper.WorldToGridPos(tileView.transform.position, _boardModel);

                TileModel tileModel = _boardModel.AddTile(gridPos);

                tileView.SetModel(tileModel);
            }
        }

        private void SetBoardPieces()
        {
            //TODO: add all pieces based on the Rows and Collumns
            GridPos gridPos = new GridPos(0, 0);

            PieceModel pieceModel = _boardModel.AddPiece(gridPos, PieceColor.Dark, PieceType.Pawn);

            GameObject piece = GameObject.Instantiate(_pawnPiece);
            piece.transform.position = PositionHelper.GridToWorldPos(gridPos, _boardModel);
            piece.GetComponent<PieceView>().SetModel(pieceModel);
        }
    }
}
