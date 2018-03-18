using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Spawn : MonoBehaviour {
	
	public GameObject bullet;
	public Transform spawnPoint;
	
	
	void fixedUpdate(){
		
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		bool shoot = Input.GetMouseButtonDown(0);
		if(shoot){
			GameObject bulletHolder = Instantiate(bullet) as GameObject;
			bulletHolder.transform.position = spawnPoint.transform.position;
			bulletHolder.transform.rotation = spawnPoint.transform.rotation;
			AudioSource shootSound = GetComponent<AudioSource>();
			shootSound.Play();
			
		}
	}
}
