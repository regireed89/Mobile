using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using System.Linq;

public class MapGenerator : MonoBehaviour {

    
    public Transform tilePrefab;
    public List<GameObject> tiles;
    public Vector2 mapSize;
    
    [Range(0,1)]
    public float outLinePercent;
    Transform mapHolder;
    
    private void Start()
    {
        tiles = GameObject.FindGameObjectsWithTag("Tile").ToList<GameObject>();
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
            foreach (var v in tiles)
            {
                v.GetComponent<Renderer>().material.color = Color.green;
            }
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
            for(int j = 0; j < mapSize.y; j++)
            {             
                Vector3 tilePosition = new Vector3(-mapSize.x/2 + 0.5f + i, 0, -mapSize.y / 2 + 0.5f + j);
                Transform newTile = Instantiate(tilePrefab, tilePosition, Quaternion.Euler(Vector3.right * 90)) as Transform;
                newTile.localScale = Vector3.one * (1 - outLinePercent);
                newTile.parent = mapHolder;
            }
        }
    }
}
