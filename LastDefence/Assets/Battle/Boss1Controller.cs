using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1Controller : MonoBehaviour {

    // Health
    private int health;
    public int maxHealth;

    // Movement
    [SerializeField]
    Transform[] waypoints;
    [SerializeField]
    float moveSpeed = 2f;
    int waypointIndex;
    private bool forward;
    int defeatedMoveFrames = 0;
    Vector2 defeatedFinalPos;

    public bool defeated = false;
    public bool intro = true;
    public bool halfHealth = false;

    // Prefabs
    public GameObject explosionPrefab;      // Drag and drop the prefabs into here through the Unity inspector
    public GameObject explosionPrefab2;
    private GameObject explosionPrefabClone;

    // Gameobjects
    GameObject bossHealth;

    GameObject GM;
    private GameManager GMScript;

    // Use this for initialization
    void Start () {
        transform.position = new Vector3(0f, 7.11f, 0f);
        forward = true;
        health = maxHealth;

        //disable hit box, boss health, and firing until after intro
        GetComponent<PolygonCollider2D>().enabled = false;
        bossHealth = GameObject.Find("BossHealth");
        bossHealth.SetActive(false);
        GameObject.Find("Tank").GetComponent<Bullet_Spawn>().enabled = false;

        GM = GameObject.Find("GameManager");        //GameObject.Find to get GameManager
        GMScript = GM.GetComponent<GameManager>();  //GetComponent to access GameManager script inside object
        GMScript.bossLevel = true;
    }
	
	// Update is called once per frame
	void Update () {
        if (!defeated && !intro)
        {
            Move();
        }
        else if (intro)
        {
            IntroMove();
        }
        else if (defeated)
        {
            DefeatedMove();
        }
	}

    void OnCollisionEnter2D (Collision2D collisionInfo)
    {
        if (collisionInfo.collider.tag.Equals("PlayerProjectile") && !GameObject.Find("Canvas").GetComponent<upgradesDummy>().stop )
        {
            DecreaseHealth();
            GameObject.Find("Canvas").GetComponent<upgradesDummy>().DummyIncreaseScore();
            // Choosing randomly which of the two explosions to use
            if (Random.Range(0f, 1f) > 0.5)
            {
                explosionPrefabClone = Instantiate(explosionPrefab, collisionInfo.transform.position, Quaternion.identity);
            }
            else
            {
                explosionPrefabClone = Instantiate(explosionPrefab2, collisionInfo.transform.position, Quaternion.identity);
            }
            Destroy(explosionPrefabClone, 1.7f); //time to kill explosion is currently hardcoded in
        }
    }

    private void DecreaseHealth()
    {
        health--;
        float healthPerc = (float)health / maxHealth;
        GameObject.Find("BossHealthCurrent").transform.localScale = new Vector3(healthPerc, 1, 1);
        if (health == 0)
        {
            Defeated();
            GameObject.Find("Canvas").GetComponent<upgradesDummy>().WinLevel();
        }
        else if (health <= maxHealth/2)
        {
            halfHealth = true;
        }
    }

    private void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position,
            waypoints[waypointIndex].transform.position, 
            moveSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, waypoints[waypointIndex].transform.position) <= 0.1) {
            waypointIndex = forward ? waypointIndex + 1 : waypointIndex - 1;
        }

        if (waypointIndex == waypoints.Length - 1)
        {
            forward = false;
        }
        else if (waypointIndex == 0)
        {
            forward = true;
        }
    }

    private void Defeated()
    {
        if (!GameObject.Find("Canvas").GetComponent<upgradesDummy>().stop)
        {
            GetComponent<PolygonCollider2D>().enabled = false;
            defeated = true;
            defeatedFinalPos = new Vector2(transform.position.x, -3.77f);
        }
    }

    private void DefeatedMove()
    {
        transform.position = Vector2.MoveTowards(transform.position,
            defeatedFinalPos,
            moveSpeed * Time.deltaTime);
        if (Vector2.Distance(transform.position, defeatedFinalPos) > 0.1)
        {
            // Execute every 3 frames moving down
            defeatedMoveFrames++;
            if (defeatedMoveFrames >= 5)
            {
                defeatedMoveFrames = 0;
                float randX = Random.Range(-2.7f, 2.7f);
                float randY = Random.Range(-1f, 1);
                explosionPrefabClone = Instantiate(explosionPrefab, 
                    new Vector2(transform.position.x + randX, transform.position.y + randY),
                    Quaternion.identity);
                Destroy(explosionPrefabClone, 1.7f);
            }
        }
    }

    private void IntroMove()
    {
        // Move to starting position
        transform.position = Vector2.MoveTowards(transform.position,
            new Vector2(transform.position.x, 2.12f),
            moveSpeed * Time.deltaTime);

        // If made it to position
        if (Vector2.Distance(transform.position, new Vector2(transform.position.x, 2.12f)) <= 0.1)
        {
            intro = false;
            GetComponent<PolygonCollider2D>().enabled = true;
            bossHealth.SetActive(true);
            GameObject.Find("Tank").GetComponent<Bullet_Spawn>().enabled = true;
        }
    }
}
