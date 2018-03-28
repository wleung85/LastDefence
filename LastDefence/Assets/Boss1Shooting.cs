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
    private bool halfHealth = false;

    public float bulletForce = 1;
    public float bulletFireRate = 2f;
    float timeToFire = 0;
    public float bombFireRate = 3f;
    float timeToBomb = 0;
    public float bombYForce = 0.3f;
    private Vector2 bombForceVector;

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

        bombForceVector = new Vector2(0f, bombYForce * -1);
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
            if (Time.time > timeToFire && halfHealth == false)
            {
                timeToFire = Time.time + bulletFireRate;
                ShootBullets();
                halfHealth = GetComponent<Boss1Controller>().halfHealth;
            }
            else if (Time.time > timeToFire)
            {
                // Enemy has reached 50% hp
                bulletForce = 6;
                timeToFire = Time.time + bulletFireRate;
                ShootBullets();
            }
            if (Time.time > timeToBomb && halfHealth == true)
            {
                timeToBomb = Time.time + bombFireRate;
                ShootBombs();
            }
            defeated = GetComponent<Boss1Controller>().defeated;
        }

    }

    void ShootBullets()
    {
        Vector2 projectileDirection = (new Vector2((GameObject.Find("Tank").transform.position.x - 0.59f)/10f, GameObject.Find("Tank").transform.position.y)) - (Vector2)firePoint5.position;
        projectileDirection = projectileDirection / projectileDirection.magnitude * bulletForce;

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

    void ShootBombs()
    {
        bombPrefabClone = Instantiate(bombPrefab, firePoint1.position, Quaternion.identity);
        bombPrefabClone.GetComponent<Rigidbody2D>().AddForce(bombForceVector, ForceMode2D.Impulse);
        Destroy(bombPrefabClone, 5f);

        bombPrefabClone = Instantiate(bombPrefab, firePoint2.position, Quaternion.identity);
        bombPrefabClone.GetComponent<Rigidbody2D>().AddForce(bombForceVector, ForceMode2D.Impulse);
        Destroy(bombPrefabClone, 5f);

        bombPrefabClone = Instantiate(bombPrefab, firePoint3.position, Quaternion.identity);
        bombPrefabClone.GetComponent<Rigidbody2D>().AddForce(bombForceVector, ForceMode2D.Impulse);
        Destroy(bombPrefabClone, 5f);

        bombPrefabClone = Instantiate(bombPrefab, firePoint4.position, Quaternion.identity);
        bombPrefabClone.GetComponent<Rigidbody2D>().AddForce(bombForceVector, ForceMode2D.Impulse);
        Destroy(bombPrefabClone, 5f);

        bombPrefabClone = Instantiate(bombPrefab, firePoint5.position, Quaternion.identity);
        bombPrefabClone.GetComponent<Rigidbody2D>().AddForce(bombForceVector, ForceMode2D.Impulse);
        Destroy(bombPrefabClone, 5f);
    }
}
