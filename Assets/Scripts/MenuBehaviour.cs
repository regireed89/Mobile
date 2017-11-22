using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBehaviour : MonoBehaviour {

    public Canvas Instructions;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartGame()
    {
        SceneManager.LoadScene("0.Main");
    }
    public void LoadInstructions()
    {
        Instructions.gameObject.SetActive(true);
    }
    public void CloseGame()
    {
        Application.Quit();
    }
    public void Back()
    {
        Instructions.gameObject.SetActive(false);
    }
        
}
