using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;
	public int score;

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
