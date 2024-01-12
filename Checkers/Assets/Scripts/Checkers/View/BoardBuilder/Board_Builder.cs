using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Checkers.View;
using Checkers.Model;

public class Board_Builder : MonoBehaviour
{
    [SerializeField] public int Rows;
    [SerializeField] public int Columns;

    public GameObject ParentObject;
    public GameObject WhiteTile;
    public GameObject BlackTile;


    public void GenerateBoard()
    {
        BoardView boardView = gameObject.GetComponent<BoardView>();
        boardView._rows = Rows;
        boardView._columns = Columns;
        boardView.CreateBoardModel();

        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Columns; j++)
            {
                switch((i + j) % 2)
                {
                    case 0:
                        GameObject prefabBlack = GameObject.Instantiate(BlackTile, ParentObject.transform);
                        prefabBlack.transform.localPosition = PositionHelper.GridToWorldPos(new GridPos(i, j), boardView._boardModel);
                        break;
                    case 1:
                        GameObject prefabwhite = GameObject.Instantiate (WhiteTile, ParentObject.transform);
                        prefabwhite.transform.localPosition = PositionHelper.GridToWorldPos(new GridPos(i, j), boardView._boardModel);
                        break;
                }
            }
        }
    }

    public void ClearBoard()
    {
        TileView[] Tile = ParentObject.GetComponentsInChildren<TileView>();

        foreach (TileView tile in Tile)
        {
            DestroyImmediate(tile.gameObject);
        }
    }
}
