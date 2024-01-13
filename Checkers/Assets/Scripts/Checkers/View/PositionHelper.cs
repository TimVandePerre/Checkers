using Checkers.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Checkers.View
{
    public static class PositionHelper
    {
        public static GridPos WorldToGridPos( Vector3 worldPos, BoardModel board)
        {
            float x = worldPos.x + (board.Row / 2);
            float y = worldPos.z + (board.Column / 2);

            return new GridPos((int)x, (int)y);    
        }

        public static Vector3 GridToWorldPos( GridPos gridPos, BoardModel board )
        {
            float x = gridPos.X - (board.Row / 2) + 0.5f;
            float y = 0.3f;
            float z = gridPos.Y - (board.Column / 2) + 0.5f;

            return new Vector3(x, y, z);
        }

        public static Vector3 TileGridToWorldPos(GridPos gridPos, BoardModel board)
        {
            float x = gridPos.X - (board.Row / 2) + 0.5f;
            float y = 0;
            float z = gridPos.Y - (board.Column / 2) + 0.5f;

            return new Vector3(x, y, z);
        }
    }
}
