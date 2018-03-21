using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour {

    void OnCollisionEnter2D (Collision2D collisionInfo)
    {
        if(collisionInfo.collider.tag.Equals("EnemyProjectile"))
        {
            GameObject.Find("Canvas").GetComponent<upgradesDummy>().hitHealth();
        }
    }
}
