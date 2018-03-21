using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneDestroy : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (collisionInfo.collider.tag.Equals("PlayerProjectile"))
        {
            Destroy(gameObject);
            GameObject.Find("Canvas").GetComponent<upgradesDummy>().DummyIncreaseScore();
        }


    }
}
