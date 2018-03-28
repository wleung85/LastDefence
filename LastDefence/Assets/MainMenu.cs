using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    private GameObject GameManager;
    private GameManager GMScript;

    void Start()
    {
        GameManager = GameObject.Find("GameManager");
        GMScript = GameManager.GetComponent<GameManager>();
    }

	public void PlayGame ()
    {
        GMScript.sizeLevel = 0;
        GMScript.speedLevel = 0;
        GMScript.rateLevel = 0;
        GMScript.healthLevel = 0;
        GMScript.score = 0;
        GMScript.level1Beat = false;
        SceneManager.LoadScene("Cinematic");
    }

    public void QuitGame ()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
