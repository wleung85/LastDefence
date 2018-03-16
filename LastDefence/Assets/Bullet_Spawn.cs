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
			Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);
		}
	}
}
