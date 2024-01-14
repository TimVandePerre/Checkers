using Checkers.View;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Checkers.Model
{
    public class PieceView : MonoBehaviour
    {
        [SerializeField] private Renderer _renderer;
        [SerializeField] private Material _highlightMaterial;
        [SerializeField] private GameObject _kingPrefab;

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
            PieceModel.PositionChanged += PieceModel_PositionChanged;
            PieceModel.PieceRemoved += PieceModel_PieceRemoved;
            PieceModel.PieceUpgrade += PieceModel_PieceUpgrade;
        }

        private void PieceModel_PositionChanged(object sender, PositionEventArgs e)
        {
            transform.position = PositionHelper.GridToWorldPos(e.GridPos, PieceModel._board);
        }

        private void PieceModel_PieceColorChanged(object sender, PieceColorEventArgs e)
        {
            if (e.PieceColor)
            {
                _renderer.sharedMaterial = _highlightMaterial;
            }
            else _renderer.sharedMaterial = _defaultMaterial;
        }

        private void PieceModel_PieceRemoved(object sender, EventArgs e)
        {
            Destroy(gameObject);
        }

        private void PieceModel_PieceUpgrade(object sender, EventArgs e)
        {
            GameObject obj = Instantiate(_kingPrefab, this.transform);
            Destroy(_renderer.gameObject);
            _renderer = obj.GetComponent<Renderer>();
        }
    }
}
