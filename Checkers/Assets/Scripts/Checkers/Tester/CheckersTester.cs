using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Checkers.Model;
using Checkers.Model.Engine;
using Checkers.View;

public class CheckersTester : MonoBehaviour
{
    BoardModel _boardModel;
    // Start is called before the first frame update
    void Start()
    {
        _boardModel = FindObjectOfType<BoardView>().BoardModel;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
