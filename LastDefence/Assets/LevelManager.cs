using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {
    public int min;
    public int max;
    public float minY;
    public float maxY;
    public GameObject enemy1;
    public float time;

    void Start()
    {
        minY = 0f;
        maxY = 3.5f;
        time = 0;
        spawnCycle();
    }

    void Update()
    {
        time += Time.deltaTime;
    }

    private IEnumerator spawnCycle()
    {
        while (true)
        {
            if (time >= 4)
            {
                time = 0;
                createEnemy1();
            }
        }
    }

    public void createEnemy1()
    {
        Instantiate(enemy1, new Vector3(9.4f, Random.Range(minY, maxY), 0f), Quaternion.identity);
    }
}
