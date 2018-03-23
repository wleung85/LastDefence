using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour {

	public float speed;
	private Renderer renderer; 
	private float offset;

	private void Start() { 
		renderer = GetComponent<Renderer>(); 
	} 

	private void Update() { 
		//renderer.material.mainTextureOffset = new Vector2(Time.time * speed, 0); 
		float horizontal = Input.GetAxis ("Horizontal");
		offset = offset + (horizontal * speed);
		renderer.material.mainTextureOffset = new Vector2(offset, 0);
	}﻿
}
