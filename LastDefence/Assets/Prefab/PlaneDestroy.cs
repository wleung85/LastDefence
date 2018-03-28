using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneDestroy : MonoBehaviour {

    public GameObject explosionPrefab;
    private GameObject explosionPrefabClone;
    GameObject GM;
    private GameManager GMScript;

    private void Start()
    {
        GM = GameObject.Find("GameManager");        //GameObject.Find to get GameManager
        GMScript = GM.GetComponent<GameManager>();	//GetComponent to access GameManager script inside object
        Destroy(gameObject, 7f);
    }


    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (collisionInfo.collider.tag.Equals("PlayerProjectile"))
        {
            //gameObject.transform.localScale = new Vector3(0, 0, 0);
            Destroy(gameObject);
            explosionPrefabClone = Instantiate(explosionPrefab, collisionInfo.transform.position, Quaternion.identity);
            GameObject.Find("Canvas").GetComponent<upgradesDummy>().DummyIncreaseScore();
            GMScript.planeHit++;
            Destroy(explosionPrefabClone, 1f);
        }

        if (collisionInfo.collider.tag.Equals("Walls"))
        {
            Destroy(gameObject);
        }
    }
}
