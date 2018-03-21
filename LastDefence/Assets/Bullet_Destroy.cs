using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet_Destroy : MonoBehaviour {

	public Transform bullet;
	public float collisionRadius = 0f;
	public bool collided = false;
	public LayerMask whatToCollideWith;
	
	void FixedUpdate(){
		collided = Physics2D.OverlapCircle(bullet.position,collisionRadius, whatToCollideWith);
		if(collided)
			Destroy(gameObject);
		if(!GetComponent<Renderer>().isVisible)
			Destroy(gameObject);
	}
    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (collisionInfo.collider.tag.Equals("EnemyProjectile") || collisionInfo.collider.tag.Equals("Enemy")) 
        {
            Destroy(gameObject);
        }

    }
}
