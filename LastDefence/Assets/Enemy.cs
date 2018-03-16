using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float speed = 5f;
    GameObject ebomb;

    // Use this for initialization
    void Start()
    {
        ebomb = Resources.Load("Battle/bomb1") as GameObject;
    }
	
	// Update is called once per frame
	void Update () 
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        GameObject bomb = Instantiate(ebomb) as GameObject;
        bomb.transform.Translate(Vector3.down * speed * Time.deltaTime);
	}
}
