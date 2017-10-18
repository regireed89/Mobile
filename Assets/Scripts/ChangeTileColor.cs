using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTileColor : MonoBehaviour
{
    private bool currentTile;
    private bool tagged;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
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
     }
}
