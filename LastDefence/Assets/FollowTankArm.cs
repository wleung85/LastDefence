using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTankArm : MonoBehaviour {

	[SerializeField]
	Transform shootingPoint;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = shootingPoint.transform.position;
		transform.rotation = shootingPoint.transform.rotation;
	}
}
