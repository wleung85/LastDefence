using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBombDestroy : MonoBehaviour
{

    public int health;
    public GameObject explosionPrefab;
    private GameObject explosionPrefabClone;

    /*void OnCollisionEnter2D(Collision2D collisionInfo)
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
            health--;
            if (health <= 0)
            {
                Destroy(gameObject);
                AudioSource explosionSound = GetComponent<AudioSource>();
                explosionPrefabClone = Instantiate(explosionPrefab, gameObject.transform.position, Quaternion.identity);
                Destroy(explosionPrefabClone, 1f);
            }
        }
        else if (collisionInfo.collider.tag.Equals("Obstacle"))
        {
            Destroy(gameObject);
            AudioSource explosionSound = GetComponent<AudioSource>();
            explosionPrefabClone = Instantiate(explosionPrefab, gameObject.transform.position, Quaternion.identity);
            Destroy(explosionPrefabClone, 1f);
        }
    }*/

    private void OnTriggerEnter2D(Collider2D collisionInfo)
    {
        if (collisionInfo.tag.Equals("Player"))
        {
            //AudioSource explosionSound = GetComponent<AudioSource>();
            explosionPrefabClone = Instantiate(explosionPrefab, gameObject.transform.position, Quaternion.identity);
            Destroy(explosionPrefabClone, 1f);
            Destroy(gameObject);
        }
        else if (collisionInfo.tag.Equals("PlayerProjectile"))
        {
            health--;

            Destroy(collisionInfo.gameObject);  // Destroy player projectile on hit
            if (health <= 0)
            {
                Destroy(gameObject);
                GameObject.Find("Canvas").GetComponent<upgradesDummy>().DummyIncreaseScore();
            }
            explosionPrefabClone = Instantiate(explosionPrefab, gameObject.transform.position, Quaternion.identity);
            Destroy(explosionPrefabClone, 1f);
        }
        else if (collisionInfo.tag.Equals("Obstacle"))
        {
            //AudioSource explosionSound = GetComponent<AudioSource>();
            explosionPrefabClone = Instantiate(explosionPrefab, gameObject.transform.position, Quaternion.identity);
            Destroy(explosionPrefabClone, 1f);
            Destroy(gameObject);
        }
    }
}
