using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{

    public GameObject bulletPrefab;
    private GameObject bulletPrefabClone;
    private bool intro = true;
    private bool canShoot = true;
    public float speed = 5f;

    public float bulletForce;
    public float bulletFireRate;
    float timeToFire;

    public Transform firePoint1;

    // Use this for initialization
    void Start()
    {
        bulletForce = 1;
        bulletFireRate = 2f;
        timeToFire = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (Time.time > timeToFire)
        {
            timeToFire = Time.time + bulletFireRate;
            ShootBullets();
        }
    }

    void ShootBullets()
    {
        Vector2 projectileDirection = (new Vector2((GameObject.Find("Tank").transform.position.x - 0.59f) / 3f, GameObject.Find("Tank").transform.position.y)) - (Vector2)firePoint1.position;
        projectileDirection = projectileDirection * bulletForce;

        bulletPrefabClone = Instantiate(bulletPrefab, firePoint1.position, Quaternion.identity);
        bulletPrefabClone.GetComponent<Rigidbody2D>().AddForce(projectileDirection, ForceMode2D.Impulse);
        Destroy(bulletPrefabClone, 5f);
    }
}
