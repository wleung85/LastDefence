using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemyTank : MonoBehaviour {

    public static float bombSpeed = 5;
    public GameObject bomb;
    public Transform spawnPoint;
    private GameObject bullet;
    private bool alreadyShot;
    private float spawnTime;
    private float time;

    public float bulletforce = -0.3f;
    private Vector2 shootDirection;

    // Use this for initialization
    void Start()
    {
        time = 0;
        shootDirection = new Vector2(bulletforce, 0f);
    }
    
    // Update is called once per frame
    void Update () 
    {

        time += Time.deltaTime;
        if (gameObject == null)
        {

        }

        else
        {
            if (!alreadyShot && time >= 3)
            {
                time = 0;
                bullet = Instantiate(bomb, spawnPoint.position, spawnPoint.rotation);
                alreadyShot = true;
            }

            if (alreadyShot)
            {
                if (bullet == null) { }
                else
                {
                    bullet.GetComponent<Rigidbody2D>().AddForce(shootDirection, ForceMode2D.Impulse);
                }

            }
        }
    }

 
}
