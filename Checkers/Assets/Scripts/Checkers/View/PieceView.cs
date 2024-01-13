using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Checkers.Model
{
    public class PieceView : MonoBehaviour
    {
        [SerializeField] private Renderer _renderer;
        [SerializeField] private Material _highlightMaterial;
        private Material _defaultMaterial;

        public PieceColor Color;
        public PieceType Type;
        public PieceModel PieceModel { get; private set; }
        public void SetModel(PieceModel model)
        {
            PieceModel = model;
            _defaultMaterial = _renderer.material;

            //TODO: subscribe to the events
            PieceModel.PieceHighlightChanged += PieceModel_PieceHighlightChanged;
        }

        private void PieceModel_PieceHighlightChanged(object sender, PieceHighlightEventArgs e)
        {
            if (e.PieceColor)
            {
                _renderer.sharedMaterial = _highlightMaterial;
            }
            else _renderer.sharedMaterial = _defaultMaterial;
        }
    }
}
