﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCube : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.touches.Length >= 1)
        {
            this.GetComponent<Rigidbody>().AddForce(Vector3.up);
        }
	}
}