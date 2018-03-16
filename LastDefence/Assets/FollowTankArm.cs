using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTankArm : MonoBehaviour {
	
	public GameObject tankArm;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = tankArm.transform.position ;
		transform.rotation = tankArm.transform.rotation;
	}
}
