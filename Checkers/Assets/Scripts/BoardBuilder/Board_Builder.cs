using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board_Builder : MonoBehaviour
{
    [SerializeField] public int Rows;
    [SerializeField] public int Columns;

    public GameObject ParentObject;
    public GameObject WhiteTile;
    public GameObject BlackTile;


    public void GenerateBoard()
    {
        Debug.Log("generate");
    }

    public void ClearBoard()
    {

    }
}
