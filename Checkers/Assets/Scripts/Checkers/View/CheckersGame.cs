using Checkers.Model.Engine;
using Checkers.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Checkers.View
{
    public class CheckersGame : MonoBehaviour
    {
        private CheckersEngine _engine;

        private void Start()
        {
            BoardView board = FindObjectOfType<BoardView>();

            _engine = new CheckersEngine(board._boardModel, PieceColor.Dark);
        }
    }
}
