using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombDestroy : MonoBehaviour
{

    public GameObject explosionPrefab;
    private GameObject explosionPrefabClone;
    public AudioClip explosionSound;

    void Start()
    {
        GetComponent<AudioSource>().playOnAwake = false;
        GetComponent<AudioSource>().clip = explosionSound;
    }


    void OnTriggerEnter2D(Collider2D collisionInfo)
    {   
        if (collisionInfo.tag.Equals("Player"))
        {
            Destroy(gameObject);
            GetComponent<AudioSource>().Play();
            explosionPrefabClone = Instantiate(explosionPrefab, gameObject.transform.position, Quaternion.identity);
            Destroy(explosionPrefabClone, 1f);
        }
        else if (collisionInfo.tag.Equals("PlayerProjectile"))
        {
            Destroy(gameObject);
            Destroy(collisionInfo.gameObject);
            GetComponent<AudioSource>().Play();
            explosionPrefabClone = Instantiate(explosionPrefab, gameObject.transform.position, Quaternion.identity);
            Destroy(explosionPrefabClone, 1f);
        }
        else if (collisionInfo.tag.Equals("Walls"))
        {
            Destroy(gameObject);
            GetComponent<AudioSource>().Play();
            explosionPrefabClone = Instantiate(explosionPrefab, gameObject.transform.position, Quaternion.identity);
            Destroy(explosionPrefabClone, 1f);
        }

        
    }
}
