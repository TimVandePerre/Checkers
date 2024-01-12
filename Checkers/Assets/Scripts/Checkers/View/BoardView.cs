using Checkers.Model;
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
        }

        public void CreateBoardModel()
        {
            _boardModel = new BoardModel(_rows, _columns);
        }
    }
}
