using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{

    public Text counterText;
    public float seconds, minutes;

    // Use this for initialization
    void Start()
    {
        counterText = GetComponent<Text>() as Text;
    }

    // Update is called once per frame
    void Update()
    {
        while (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("0.Main"))
        {
            minutes = (int)(Time.time / 60f);
            seconds = (int)(Time.time % 60);
            counterText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
        }

    }
}
