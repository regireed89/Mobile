using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTileColor : MonoBehaviour
{
   
    private void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            if (Physics.Raycast(ray, out hit))
            {
                if(hit.collider == GetComponent<Collider>())
                    GetComponent<Renderer>().material.color = Color.black;
            }
        }
    }
}
