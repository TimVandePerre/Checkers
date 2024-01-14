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
        public BoardModel BoardModel { get; private set; }

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
            BoardModel = new BoardModel(_rows, _columns);
            BoardModel.PieceSpawned += BoardModel_PieceSpawned;
        }

        private void SetBoardTiles()
        {
            TileView[] tileViews = GetComponentsInChildren<TileView>();

            foreach (TileView tileView in tileViews)
            {
                GridPos gridPos = PositionHelper.WorldToGridPos(tileView.transform.position, BoardModel);

                TileModel tileModel = BoardModel.AddTile(gridPos);

                tileView.SetModel(tileModel);
            }
        }

        private void BoardModel_PieceSpawned(object sender, PieceEventArgs e)
        {
            PieceModel pieceModel = e.Piece;

            PieceView pieceView = _prefabPiece.Where(p=> p.Color == pieceModel.PieceColor && p.Type == pieceModel.PieceType).FirstOrDefault();

            GameObject spawnedObject = GameObject.Instantiate(pieceView.gameObject, PositionHelper.GridToWorldPos(pieceModel.GridPosition, BoardModel), pieceView.transform.rotation);

            spawnedObject.GetComponent<PieceView>().SetModel(pieceModel);
        }
    }
}
