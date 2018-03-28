using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;
	public int score = 0;
    public int sizeLevel = 0;
    public int rateLevel = 0;
    public int healthLevel = 0;
    public int speedLevel = 0;
    public int planeHit = 0;
    public int tankHit = 0;
    public int bomberHit = 0;
    public bool win = true;
    public bool bossLevel = true;
    public bool level1Beat = false;

    void Awake () {
		if (instance == null) 
			instance = this;
		else if (instance != null)
			Destroy(gameObject);
		DontDestroyOnLoad(transform.gameObject);
	}

	/********************************************
	To access GameManager from another script

	GameObject GM;								//Variable holds GameManager object
	GM = GameObject.Find("GameManager");		//GameObject.Find to get GameManager
	GMScript = GM.GetComponent<GameManager>();	//GetComponent to access GameManager script inside object

	Debug.Log(GM.score);						//int score can now be accessed and used


	*********************************************/
}
