using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1Shooting : MonoBehaviour {

    public GameObject bulletPrefab;
    private GameObject bulletPrefabClone;
    public GameObject bombPrefab;
    private GameObject bombPrefabClone;
    private bool intro = true;
    private bool defeated = false;

    public float bulletForce = 1;
    public float bulletFireRate = 2f;
    float timeToFire = 0;

    Transform firePoint1;
    Transform firePoint2;
    Transform firePoint3;
    Transform firePoint4;
    Transform firePoint5;


    // Use this for initialization
    void Start () {
        firePoint1 = transform.Find("FirePoint1");
        firePoint2 = transform.Find("FirePoint2");
        firePoint3 = transform.Find("FirePoint3");
        firePoint4 = transform.Find("FirePoint4");
        firePoint5 = transform.Find("FirePoint5");
    }
	
	// Update is called once per frame
	void Update () {
        if (intro)
        {
            intro = GetComponent<Boss1Controller>().intro;
        }	
        else if (defeated) {
            // Don't shoot when defeated
        }
        else
        {
           if (Time.time > timeToFire)
            {
                timeToFire = Time.time + bulletFireRate;
                ShootBullets();
            }
        }
	}

    void ShootBullets()
    {
        Vector2 projectileDirection = (new Vector2((GameObject.Find("Tank").transform.position.x - 0.59f)/3f, GameObject.Find("Tank").transform.position.y)) - (Vector2)firePoint5.position;
        projectileDirection = projectileDirection*bulletForce;

        bulletPrefabClone = Instantiate(bulletPrefab, firePoint1.position, Quaternion.identity);
        bulletPrefabClone.GetComponent<Rigidbody2D>().AddForce(projectileDirection, ForceMode2D.Impulse);
        Destroy(bulletPrefabClone, 5f);

        bulletPrefabClone = Instantiate(bulletPrefab, firePoint2.position, Quaternion.identity);
        bulletPrefabClone.GetComponent<Rigidbody2D>().AddForce(projectileDirection, ForceMode2D.Impulse);
        Destroy(bulletPrefabClone, 5f);

        bulletPrefabClone = Instantiate(bulletPrefab, firePoint3.position, Quaternion.identity);
        bulletPrefabClone.GetComponent<Rigidbody2D>().AddForce(projectileDirection, ForceMode2D.Impulse);
        Destroy(bulletPrefabClone, 5f);

        bulletPrefabClone = Instantiate(bulletPrefab, firePoint4.position, Quaternion.identity);
        bulletPrefabClone.GetComponent<Rigidbody2D>().AddForce(projectileDirection, ForceMode2D.Impulse);
        Destroy(bulletPrefabClone, 5f);

        bulletPrefabClone = Instantiate(bulletPrefab, firePoint5.position, Quaternion.identity);
        bulletPrefabClone.GetComponent<Rigidbody2D>().AddForce(projectileDirection, ForceMode2D.Impulse);
        Destroy(bulletPrefabClone, 5f);

    }
}
