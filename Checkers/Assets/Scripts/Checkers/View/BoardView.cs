using Checkers.Model;
using System;
using System.Linq;
using UnityEngine;

namespace Checkers.View
{
    public class BoardView : MonoBehaviour
    {
        public int _rows;
        public int _columns;
        public BoardModel _boardModel { get; private set; }

        [SerializeField] private PieceView[] _prefabPiece;

        private void Awake()
        {
            _rows = gameObject.GetComponent<Board_Builder>().Rows;
            _columns = gameObject.GetComponent<Board_Builder>().Columns;

            CreateBoardModel();
            SetBoardTiles();
        }

        public void CreateBoardModel()
        {
            _boardModel = new BoardModel(_rows, _columns);
            _boardModel.PieceSpawned += _boardModel_PieceSpawned;
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

        private void _boardModel_PieceSpawned(object sender, PieceEventArgs e)
        {
            PieceModel pieceModel = e.Piece;

            PieceView pieceView = _prefabPiece.Where(p=> p.Color == pieceModel.PieceColor && p.Type == pieceModel.PieceType).FirstOrDefault();

            GameObject spawnedObject = GameObject.Instantiate(pieceView.gameObject, PositionHelper.GridToWorldPos(pieceModel.GridPosition, _boardModel), pieceView.transform.rotation);

            spawnedObject.GetComponent<PieceView>().SetModel(pieceModel);
        }
    }
}
