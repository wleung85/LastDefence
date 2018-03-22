using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1Controller : MonoBehaviour {

    public int health;

	// Use this for initialization
	void Start () {
        health = 100;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D (Collision2D collisionInfo)
    {
        Debug.Log("Collision detected");
        if (collisionInfo.collider.tag.Equals("PlayerProjectile"))
        {
            DecreaseHealth();
            Debug.Log("Position of projectile hit:" + collisionInfo.transform.position);
        }
    }

    private void DecreaseHealth()
    {
        Debug.Log("Decreasing Boss1 Health");
    }
}
