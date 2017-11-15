using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
namespace Tile
{
    [CustomEditor(typeof(MapGenerator))]
    public class MapEditor : Editor
    {

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            MapGenerator map = target as MapGenerator;
            map.GenerateMap();
        }

    }
}