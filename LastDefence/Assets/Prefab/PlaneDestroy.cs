using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneDestroy : MonoBehaviour {

    public GameObject explosionPrefab;
    private GameObject explosionPrefabClone;

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (collisionInfo.collider.tag.Equals("PlayerProjectile"))
        {
            gameObject.transform.localScale = new Vector3(0, 0, 0);
            Destroy(gameObject, 3);
            explosionPrefabClone = Instantiate(explosionPrefab, collisionInfo.transform.position, Quaternion.identity);
            GameObject.Find("Canvas").GetComponent<upgradesDummy>().DummyIncreaseScore();
            Destroy(explosionPrefabClone, 1f);
        }

        if (collisionInfo.collider.tag.Equals("Walls"))
        {
            Destroy(gameObject);
        }
    }
}
