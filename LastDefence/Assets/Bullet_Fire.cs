using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Fire : MonoBehaviour {

	public float bulletForce = 750.0f;
	GameObject GM;	
	private GameManager GMScript;
	
	
	void Start () {
		GM = GameObject.Find("GameManager");		//GameObject.Find to get GameManager
		GMScript = GM.GetComponent<GameManager>();	//GetComponent to access GameManager script inside object
	}
	void OnTriggerEnter2D(Collider2D target){
		if(target.gameObject.tag == "FirePoint")
			bulletForce = bulletForce + 100.0f * GMScript.speedLevel;
			GetComponent<Rigidbody2D>().AddForce(transform.right * bulletForce);
	}
}


	/********************************************
	To access GameManager from another script

	GameObject GM;								//Variable holds GameManager object
	GM = GameObject.Find("GameManager");		//GameObject.Find to get GameManager
	GMScript = GM.GetComponent<GameManager>();	//GetComponent to access GameManager script inside object

	Debug.Log(GM.score);						//int score can now be accessed and used


	*********************************************/
