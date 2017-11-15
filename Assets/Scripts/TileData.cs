using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tile
{
    public class TileData : ScriptableObject
    {

        public bool currentTile;
        public bool tagged;
        public List<GameObject> neighbor;

    }
}