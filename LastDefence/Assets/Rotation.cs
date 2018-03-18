using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour {

	public int rotationOffset = 0;
	public float maxAngleFront = -10f;
	public float maxAngleBack = -175f;
	public float newAngle;

	// Update is called once per frame
	void Update () {
		//structing the pos of the player from the mouse position
		Vector3 difference = Camera.main.ScreenToWorldPoint (Input.mousePosition) - transform.position;
		difference.Normalize();		//normalizing the vector meaning that all the sum of the vector = 1	
		float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;	// find the angle in deg
		newAngle = rotZ + rotationOffset;

		// Too much in the front
		if (newAngle < maxAngleFront && newAngle > -90) {
			transform.rotation = Quaternion.Euler(0f, 0f, maxAngleFront);	
		}
		
		// Too much in the back
		else if (newAngle > maxAngleBack && newAngle < -90) {
			transform.rotation = Quaternion.Euler(0f, 0f, maxAngleBack);
		}
		// Within acceptable bounds
		else 
			transform.rotation = Quaternion.Euler(0f, 0f, newAngle);
		
	}
}
