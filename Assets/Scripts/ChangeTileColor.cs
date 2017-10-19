using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;
public class ChangeTileColor : MonoBehaviour
{
    TileData data;
    public List<GameObject> tiles;
    public List<GameObject> taggedTiles;
    private void Start()
    {
        data = ScriptableObject.CreateInstance<TileData>();
        data.tagged = false;      
        tiles = GameObject.FindGameObjectsWithTag("Tile").ToList<GameObject>();
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
                v.GetComponent<Renderer>().material.color = Color.green;

            SceneManager.LoadScene("0.Main");
        }
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider == GetComponent<Collider>())
                {                                    
                    data.currentTile = true;
                    if (data.currentTile == true)
                    {
                        data.tagged = true;
                        taggedTiles.Add(this.gameObject);
                        GetComponent<Renderer>().material.color = Color.black;
                    }
                }
                if (hit.collider != GetComponent<Collider>() && data.tagged == true)
                {
                    data.currentTile = false;
                    GetComponent<Renderer>().material.color = Color.blue;
                }
            }
        }
    }
}
