using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankDestroy : MonoBehaviour
{

    public GameObject explosionPrefab;
    private GameObject explosionPrefabClone;
    GameObject GM;
    private GameManager GMScript;

    private void Start()
    {
        GM = GameObject.Find("GameManager");        //GameObject.Find to get GameManager
        GMScript = GM.GetComponent<GameManager>();	//GetComponent to access GameManager script inside object
    }

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (collisionInfo.collider.tag.Equals("PlayerProjectile"))
        {
            gameObject.transform.localScale = new Vector3(0, 0, 0);
            Destroy(gameObject, 3);
            explosionPrefabClone = Instantiate(explosionPrefab, collisionInfo.transform.position, Quaternion.identity);
            GameObject.Find("Canvas").GetComponent<upgradesDummy>().DummyIncreaseScore();
            GMScript.tankHit++;
            Destroy(explosionPrefabClone, 1f);
        }
    }
}

