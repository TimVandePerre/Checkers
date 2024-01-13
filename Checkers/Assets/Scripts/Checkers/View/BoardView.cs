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
    }
}
