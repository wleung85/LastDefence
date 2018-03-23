using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightbullet1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Physics2D.IgnoreCollision(GetComponent<CircleCollider2D>(), GameObject.Find("Tank").GetComponent<BoxCollider2D>());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
