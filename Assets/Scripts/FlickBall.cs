using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickBall : MonoBehaviour
{
    Rigidbody rb;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    Vector2 startPos;
    float startTime;
    Vector2 endPos;
    float endTIme;
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startPos = Input.GetTouch(0).position;
            startTime = Time.time;
        }
        if (Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            endPos = Input.GetTouch(0).position;
            endTIme = Time.time;

            var dis = startPos - endPos;
            var time = startTime - endTIme;

            rb.AddForce(dis/(time/2), 0);
        }
    }
}
