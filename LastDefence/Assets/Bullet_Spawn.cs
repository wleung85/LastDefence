using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet_Spawn : MonoBehaviour {
	
	public GameObject bullet;
	public Transform spawnPoint;
	GameObject GM;	
	private GameManager GMScript;
	public float cooldownTime;
	public float cooldown;


	// Use this for initialization
	void Start () {
		GM = GameObject.Find("GameManager");		//GameObject.Find to get GameManager
		GMScript = GM.GetComponent<GameManager>();	//GetComponent to access GameManager script inside object
		cooldownTime = (float) (1 - .25 * GMScript.rateLevel);
		
	}
	
	// Update is called once per frame
	void Update () {
		//bool shoot = Input.GetMouseButtonDown(0);
		if(cooldown > 0){
			cooldown -= Time.deltaTime;
		}
		if(cooldown < 0){
			cooldown = 0;
		}
		
		if(Input.GetMouseButton(0) && cooldown == 0){
			GameObject bulletHolder = Instantiate(bullet) as GameObject;
			bulletHolder.transform.position = spawnPoint.transform.position;
			bulletHolder.transform.rotation = spawnPoint.transform.rotation;
			bulletHolder.transform.localScale = new Vector3(0.04773423F + 0.01f * GMScript.sizeLevel, 0.04773423F + 0.01f * GMScript.sizeLevel, 0.04773423F);
			AudioSource shootSound = GetComponent<AudioSource>();
			shootSound.Play();
			cooldown = cooldownTime;
		}
	}
	
}
