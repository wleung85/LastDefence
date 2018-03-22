using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1Controller : MonoBehaviour {

    public int health;
    public GameObject explosionPrefab;      // Drag and drop the prefabs into here through the Unity inspector
    public GameObject explosionPrefab2;
    private GameObject explosionPrefabClone;

	// Use this for initialization
	void Start () {
        health = 100;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D (Collision2D collisionInfo)
    {
        if (collisionInfo.collider.tag.Equals("PlayerProjectile"))
        {
            DecreaseHealth();
            // Choosing randomly which of the two explosions to use
            if (Random.Range(0f, 1f) > 0.5)
            {
                explosionPrefabClone = Instantiate(explosionPrefab, collisionInfo.transform.position, Quaternion.identity);
            }
            else
            {
                explosionPrefabClone = Instantiate(explosionPrefab2, collisionInfo.transform.position, Quaternion.identity);
            }
            Destroy(explosionPrefabClone, 1.2f); //time to kill explosion is currently hardcoded in
        }
    }

    private void DecreaseHealth()
    {
        Debug.Log("DecreaseHealth() function called");
    }
}
