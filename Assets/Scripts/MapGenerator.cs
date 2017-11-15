using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using System.Linq;

namespace Tile
{


    public class MapGenerator : MonoBehaviour
    {


        public Transform tilePrefab;
        public List<GameObject> tiles;
        public Vector2 mapSize;
        public GameObject current;

        [Range(0, 1)]
        public float outLinePercent;
        Transform mapHolder;

        private void Start()
        {
            tiles = GameObject.FindGameObjectsWithTag("Tile").ToList<GameObject>();

            foreach (GameObject g in tiles)
                GetNeighbors(g);
        }
        public void OnInspectorGUI()
        {
            EditorGUILayout.Slider(outLinePercent, 0, 1);
            EditorGUILayout.Slider(mapSize.x, 3, 10);
            EditorGUILayout.Slider(mapSize.y, 3, 10);
        }
        private void Update()
        {
            bool alltagged = false;
            foreach (var v in tiles)
            {
                if (!v.GetComponent<ChangeTileColor>().data.tagged)
                {
                    alltagged = false;
                    break;
                }
                else
                {
                    alltagged = true;
                }
            }
            if (alltagged)
            {
                //foreach (var v in tiles)
                //{
                //    v.GetComponent<Renderer>().material.color = Color.green;
                //}
                SceneManager.LoadScene("0.Main");
            }
        }

        public void GenerateMap()
        {
            string holderName = "Generated Map";
            if (transform.Find(holderName))
            {
                DestroyImmediate(transform.Find(holderName).gameObject, false);
            }
            Transform mapHolder = new GameObject(holderName).transform;
            mapHolder.parent = transform;
            for (int i = 0; i < mapSize.x; i++)
            {
                for (int j = 0; j < mapSize.y; j++)
                {
                    Vector3 tilePosition = new Vector3(-mapSize.x / 2 + 0.5f + i, 0, -mapSize.y / 2 + 0.5f + j);
                    Transform newTile = Instantiate(tilePrefab, tilePosition, Quaternion.Euler(Vector3.right * 90)) as Transform;
                    newTile.localScale = Vector3.one * (1 - outLinePercent);
                    newTile.parent = mapHolder;
                }
            }
        }

        public void GetNeighbors(GameObject g)
        {
            Vector3 top = g.transform.position + Vector3.forward;
            Vector3 bot = g.transform.position + Vector3.back;
            Vector3 left = g.transform.position + Vector3.left;
            Vector3 right = g.transform.position + Vector3.right;
            Vector3 topL = g.transform.position + Vector3.forward + Vector3.left;
            Vector3 topR = g.transform.position + Vector3.forward + Vector3.right;
            Vector3 botL = g.transform.position + Vector3.back + Vector3.left;
            Vector3 botR = g.transform.position + Vector3.back + Vector3.right;
            foreach (GameObject o in tiles)
            {
                if (o.transform.position == top)
                    g.GetComponent<ChangeTileColor>().data.neighbor.Add(o.gameObject);
                if (o.transform.position == bot)
                    g.GetComponent<ChangeTileColor>().data.neighbor.Add(o.gameObject);
                if (o.transform.position == left)
                    g.GetComponent<ChangeTileColor>().data.neighbor.Add(o.gameObject);
                if (o.transform.position == right)
                    g.GetComponent<ChangeTileColor>().data.neighbor.Add(o.gameObject);
                if (o.transform.position == topL)
                    g.GetComponent<ChangeTileColor>().data.neighbor.Add(o.gameObject);
                if (o.transform.position == topR)
                    g.GetComponent<ChangeTileColor>().data.neighbor.Add(o.gameObject);
                if (o.transform.position == botL)
                    g.GetComponent<ChangeTileColor>().data.neighbor.Add(o.gameObject);
                if (o.transform.position == botR)
                    g.GetComponent<ChangeTileColor>().data.neighbor.Add(o.gameObject);
            }
        }
    }
}