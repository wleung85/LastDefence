using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightbullet1 : MonoBehaviour {

    public GameObject explosionPrefab;
    private GameObject explosionPrefabClone;

    private void Start()
    {
    }

    private void OnTriggerEnter2D(Collider2D collisionInfo)
    {
        if (collisionInfo.tag.Equals("Obstacle"))
        {
            Destroy(gameObject);
        }
        else if (collisionInfo.tag.Equals("Player"))
        {
            explosionPrefabClone = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(explosionPrefabClone, 1.7f);
            Destroy(gameObject);
        }
    }
}
