using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ChangeTileColor : MonoBehaviour
{

    public TileData data;

    private void Start()
    {
        data = ScriptableObject.CreateInstance<TileData>();
        data.tagged = false;
    }

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

                    data.currentTile = true;
                    if (data.currentTile == true)
                    {
                        data.tagged = true;
                        GetComponent<Renderer>().material.color = Color.red;
                    }
                }
                if (hit.collider != GetComponent<Collider>() && data.tagged == true)
                {
                    data.currentTile = false;
                    GetComponent<Collider>().enabled = false;
                    GetComponent<Renderer>().material.color = Color.blue;
                }
            }
        }
    }
}