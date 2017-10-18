using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTileColor : MonoBehaviour
{
    private bool currentTile;
    private bool tagged;
    GameObject map;
    private void Update()
    {
        if (Input.touchCount == 1)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider == GetComponent<Collider>())
                {
                   
                    currentTile = true;
                    tagged = true;
                    if (currentTile == true && tagged == true)
                        GetComponent<Renderer>().material.color = Color.black;
                    if (tagged == true && currentTile == false)
                    {
                        currentTile = false;
                        GetComponent<Renderer>().material.color = Color.blue;
                    }
                }
            }
        }
        foreach(Transform tile in map.GetComponent<MapGenerator>().tiles)
        {
            if(tile.GetComponent<ChangeTileColor>().tagged == true)
                GetComponent<Renderer>().material.color = Color.green;
        }
    }
}
