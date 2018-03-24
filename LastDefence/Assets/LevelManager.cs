using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {
    public int min;
    public int max;
    public float minY;
    public float maxY;
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public float time;
    public float tankTime;
    public GameObject projectile1;

    void Start()
    {
        minY = 0f;
        maxY = 3.5f;
        time = 0;
        tankTime = 0;
        Physics2D.IgnoreCollision(enemy1.GetComponent<Collider2D>(), projectile1.GetComponent<Collider2D>());
    }

    void Update()
    {
        time += Time.deltaTime;
        tankTime += Time.deltaTime;

        if (time >= 1)
        {
            time = 0;
            createEnemy1();
            createEnemy1();
            createEnemy2();
        }
        if (tankTime >= 10)
        {
            tankTime = 0;
            createEnemy3(); 
        }
    }

    public void createEnemy1()
    {
        Instantiate(enemy1, new Vector3(9.4f, Random.Range(minY, maxY), 0f), Quaternion.identity);
    }

    public void createEnemy2()
    {
        Instantiate(enemy2, new Vector3(9.4f, Random.Range(minY, maxY), 0f), Quaternion.identity);
    }

    public void createEnemy3()
    {
        Instantiate(enemy3, new Vector3(7.8f, -2.65f, 0f), Quaternion.identity);
    }
}
