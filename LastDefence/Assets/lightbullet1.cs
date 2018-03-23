using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightbullet1 : MonoBehaviour {

    public GameObject explosionPrefab;
    private GameObject explosionPrefabClone;

    private void Start()
    {
    }

    private void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (collisionInfo.collider.tag.Equals("Obstacle"))
        {
            Destroy(gameObject);
        }
        else if (collisionInfo.collider.tag.Equals("Player"))
        {
            explosionPrefabClone = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(explosionPrefabClone, 1.7f);
            Destroy(gameObject);
        }
    }
}
