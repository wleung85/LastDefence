using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

    public static float speed = 5f;
    public static float bombSpeed = 5;
    public GameObject bomb;
    public Transform spawnPoint;
    private GameObject fallingBomb;
    private bool alreadyShot;
    private float spawnTime;
    private float time;

    // Use this for initialization
    void Start()
    {
        Destroy();
        alreadyShot = false;
        SetRandomTime();
        time = 0;
    }
	
	// Update is called once per frame
	void Update () 
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (!alreadyShot)
        {
            time += Time.deltaTime;
            if (time >= spawnTime)
            {
                fallingBomb = Instantiate(bomb, spawnPoint.position, spawnPoint.rotation);
                alreadyShot = true;
            }
        }

        if (alreadyShot)
        {
            fallingBomb.transform.Translate(Vector3.down * bombSpeed * Time.deltaTime);
        }
	}

    void Destroy ()
    {
        Destroy(gameObject, 9);
    }

    void SetRandomTime()
    {
        spawnTime = Random.Range(1f, 4f);
        Debug.Log(spawnTime);
    }
}
