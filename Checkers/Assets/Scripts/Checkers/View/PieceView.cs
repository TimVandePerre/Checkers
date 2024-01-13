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

        public PieceColor Color;
        public PieceType Type;

        private Material _defaultMaterial;
        public void SetModel(PieceModel model)
        {
            PieceModel = model;

            _defaultMaterial = _renderer.material;
            //TODO: subscribe to the events
            PieceModel.PieceColorChanged += PieceModel_PieceColorChanged;
        }

        private void PieceModel_PieceColorChanged(object sender, PieceColorEventArgs e)
        {
            if (e.PieceColor)
            {
                _renderer.sharedMaterial = _highlightMaterial;
            }
            else _renderer.sharedMaterial = _defaultMaterial;
        }
    }
}
