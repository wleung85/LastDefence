using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombDestroy : MonoBehaviour
{

    public GameObject explosionPrefab;
    private GameObject explosionPrefabClone;

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (collisionInfo.collider.tag.Equals("Player"))
        {
            Destroy(gameObject);
            AudioSource explosionSound = GetComponent<AudioSource>();
            explosionPrefabClone = Instantiate(explosionPrefab, gameObject.transform.position, Quaternion.identity);
            Destroy(explosionPrefabClone, 1f);
        }
        else if (collisionInfo.collider.tag.Equals("PlayerProjectile"))
        {
            Destroy(gameObject);
            AudioSource explosionSound = GetComponent<AudioSource>();
            explosionPrefabClone = Instantiate(explosionPrefab, gameObject.transform.position, Quaternion.identity);
            Destroy(explosionPrefabClone, 1f);
        }
        else if (collisionInfo.collider.tag.Equals("Walls"))
        {
            Destroy(gameObject);
            AudioSource explosionSound = GetComponent<AudioSource>();
            explosionPrefabClone = Instantiate(explosionPrefab, gameObject.transform.position, Quaternion.identity);
            Destroy(explosionPrefabClone, 1f);
        }

        
    }
}
