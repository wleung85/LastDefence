using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombDestroy : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (collisionInfo.collider.tag.Equals("Player") || collisionInfo.collider.tag.Equals("PlayerProjectile"))
        {
            Destroy(gameObject);
        }

        
    }
}
