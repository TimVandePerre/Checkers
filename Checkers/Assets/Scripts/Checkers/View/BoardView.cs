using Checkers.Model;
using UnityEngine;

namespace Checkers.View
{
    public class BoardView : MonoBehaviour
    {
        private int _rows;
        private int _columns;
        public BoardModel _boardModel { get; private set; }

        private void Awake()
        {
            _boardModel = new BoardModel(_rows,_columns);
        }
    }
}
