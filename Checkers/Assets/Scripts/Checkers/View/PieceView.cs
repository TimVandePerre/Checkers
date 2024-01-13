using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Checkers.Model
{
    public class PieceView : MonoBehaviour
    {
        [SerializeField] private Renderer _renderer;
        [SerializeField] private Material _highlightMaterial;

        public PieceModel PieceModel { get; private set; }
        public void SetModel(PieceModel model)
        {
            PieceModel = model;
            //TODO: subscribe to the events
        }
    }
}
