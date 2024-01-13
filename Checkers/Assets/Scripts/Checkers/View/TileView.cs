using Checkers.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Checkers.View
{
    public class TileView : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField]private Renderer _renderer;
        [SerializeField] private Material _default, _highlight;


        public TileModel TileModel { get; private set; }

        public void OnPointerClick(PointerEventData eventData)
        {
            TileModel.TileClicked();
        }

        public void SetModel(TileModel tile)
        {
            TileModel = tile;
            tile.ColorChanged += Tile_ColorChanged;
        }

        private void Tile_ColorChanged(object sender, TileColorEventArgs e)
        {
            switch (e.Color)
            {
                case TileColor.Base:
                    _renderer.sharedMaterial = _default;
                    break;
                case TileColor.Highlight:
                    _renderer.sharedMaterial = _highlight;
                    break;
            }
        }
    }
}
