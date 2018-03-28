using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public int min;
    public int max;
    public float minY;
    public float maxY;
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public float time;
    public float time2;
    public float tankTime;
    public GameObject projectile1;
    public GameObject projectile2;
    public GameObject projectile3;
    public bool loop = true;
    GameObject GM;
    private GameManager GMScript;

    public float TimeToFinish = 10f;
    private float StartTime;
    private bool levelCompleted = false;

    void Start()
    {
        GM = GameObject.Find("GameManager");        //GameObject.Find to get GameManager
        GMScript = GM.GetComponent<GameManager>();  //GetComponent to access GameManager script inside object
        GMScript.bossLevel = false;
        GMScript.planeHit = 0;
        GMScript.bomberHit = 0;
        GMScript.tankHit = 0;
        StartCoroutine(Ready());
        AudioSource backgroundMusic = GetComponent<AudioSource>();
        StartTime = Time.time;
    }

    void Update()
    {
        if (Time.time - StartTime > TimeToFinish)
        {
            levelCompleted = true;
        }
        if (Time.time - StartTime > TimeToFinish + 5f)
        {
            GMScript.level1Beat = true;
            GameObject.Find("Canvas").GetComponent<upgradesDummy>().WinLevel();
        }
        if (!loop && !levelCompleted)
        {
            time += Time.deltaTime;
            time2 += Time.deltaTime;
            tankTime += Time.deltaTime;

            if (time >= 1)
            {
                time = 0;
                createEnemy1();

            }

            if (time2 >= 2.5)
            {
                time2 = 0;
                createEnemy2();
            }
            if (tankTime >= 10)
            {
                tankTime = 0;
                createEnemy3();
            }
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

    IEnumerator Ready()
    {
        Text dot = GameObject.Find("Dots").GetComponent<Text>();
        dot.text = ".";
        yield return new WaitForSeconds(1);
        dot.text = ".   .";
        yield return new WaitForSeconds(1);
        dot.text = ".   .   .";
        yield return new WaitForSeconds(1);
        GameObject.Find("Go").GetComponent<Image>().enabled = true;
        yield return new WaitForSeconds(1);
        GameObject.Find("Go").GetComponent<Image>().enabled = false;
        GameObject.Find("Ready").GetComponent<Image>().enabled = false;
        dot.text = "";
        loop = false;
        minY = 0f;
        maxY = 3.5f;
        time = 0;
        time2 = 0;
        tankTime = 0;
        Physics2D.IgnoreCollision(enemy1.GetComponent<Collider2D>(), projectile1.GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(enemy1.GetComponent<Collider2D>(), projectile2.GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(enemy1.GetComponent<Collider2D>(), projectile3.GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(enemy2.GetComponent<Collider2D>(), projectile1.GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(enemy2.GetComponent<Collider2D>(), projectile2.GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(enemy2.GetComponent<Collider2D>(), projectile3.GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(enemy3.GetComponent<Collider2D>(), projectile1.GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(enemy3.GetComponent<Collider2D>(), projectile2.GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(enemy3.GetComponent<Collider2D>(), projectile3.GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(projectile1.GetComponent<Collider2D>(), projectile1.GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(projectile1.GetComponent<Collider2D>(), projectile2.GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(projectile1.GetComponent<Collider2D>(), projectile3.GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(projectile2.GetComponent<Collider2D>(), projectile1.GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(projectile2.GetComponent<Collider2D>(), projectile2.GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(projectile2.GetComponent<Collider2D>(), projectile3.GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(projectile3.GetComponent<Collider2D>(), projectile1.GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(projectile3.GetComponent<Collider2D>(), projectile2.GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(projectile3.GetComponent<Collider2D>(), projectile3.GetComponent<Collider2D>());

    }
}