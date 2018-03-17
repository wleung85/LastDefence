using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

    public float speed = 5f;
    public float bombSpeed = 5f;
    public GameObject bomb;
    public Transform spawnPoint;
    public GameObject fallingBomb;

    // Use this for initialization
    void Start()
    {
        bomb = GameObject.Find("Bomb");
        spawnPoint = GameObject.Find("Plane").transform;
    }
	
	// Update is called once per frame
	void Update () 
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        Destroy();
        bool shoot = Input.GetKeyDown(KeyCode.A);
        if (shoot)
        {
            fallingBomb = Instantiate(bomb, spawnPoint.position, spawnPoint.rotation);
        }
        fallingBomb.transform.Translate(Vector3.down * bombSpeed * Time.deltaTime);
	}

    void Destroy ()
    {
        Destroy(gameObject, 5);
    }
}
