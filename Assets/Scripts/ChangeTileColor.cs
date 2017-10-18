using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class ChangeTileColor : MonoBehaviour
{
    public TileData data;
    public List<GameObject> tiles;
    private void Start()
    {
        data.tagged = false;
        data = ScriptableObject.CreateInstance<TileData>();
        tiles = GameObject.FindGameObjectsWithTag("Tile").ToList<GameObject>();
    }
    private void Update()
    {
        bool alltagged = false;
        foreach(var v in tiles)
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
        if(alltagged)
        {
            foreach (var v in tiles)
                v.GetComponent<Renderer>().material.color = Color.green;
        }
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider == GetComponent<Collider>())
                {
                    if (data.tagged == true)
                        return;
                    data.currentTile = true;
                    data.tagged = true;
                    if (data.currentTile == true && data.tagged == true)
                        GetComponent<Renderer>().material.color = Color.black;
                }
                if(hit.collider != GetComponent<Collider>() && data.tagged == true)
                {
                    data.currentTile = false;
                    GetComponent<Renderer>().material.color = Color.blue;
                }
            }
        }      
     }
}
