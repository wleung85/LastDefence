using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1Shooting : MonoBehaviour {

    public GameObject bulletPrefab;
    private GameObject bulletPrefabClone;
    public GameObject bombPrefab;
    private GameObject bombPrefabClone;
    private bool intro = true;
    private bool canShoot = true;

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
        else
        {
            if (canShoot)
            {
                ShootBullets();
                canShoot = false;
            }
        }
	}

    void ShootBullets()
    {
        Vector2 projectileDirection = GameObject.Find("Tank").transform.position - firePoint5.position;
        projectileDirection = projectileDirection*25;

        bulletPrefabClone = Instantiate(bulletPrefab, firePoint1.position, Quaternion.identity);
        bulletPrefabClone.GetComponent<Rigidbody2D>().AddRelativeForce(projectileDirection); Destroy(bulletPrefabClone, 5f);
        Destroy(bulletPrefabClone, 5f);

        bulletPrefabClone = Instantiate(bulletPrefab, firePoint2.position, Quaternion.identity);
        bulletPrefabClone.GetComponent<Rigidbody2D>().AddForce(projectileDirection); Destroy(bulletPrefabClone, 5f);
        Destroy(bulletPrefabClone, 5f);

        bulletPrefabClone = Instantiate(bulletPrefab, firePoint3.position, Quaternion.identity);
        bulletPrefabClone.GetComponent<Rigidbody2D>().AddForce(projectileDirection); Destroy(bulletPrefabClone, 5f);
        Destroy(bulletPrefabClone, 5f);

        bulletPrefabClone = Instantiate(bulletPrefab, firePoint4.position, Quaternion.identity);
        bulletPrefabClone.GetComponent<Rigidbody2D>().AddForce(projectileDirection); Destroy(bulletPrefabClone, 5f);
        Destroy(bulletPrefabClone, 5f);

        bulletPrefabClone = Instantiate(bulletPrefab, firePoint5.position, Quaternion.identity);
        bulletPrefabClone.GetComponent<Rigidbody2D>().AddForce(projectileDirection); Destroy(bulletPrefabClone, 5f);
        Destroy(bulletPrefabClone, 5f);

    }
}
