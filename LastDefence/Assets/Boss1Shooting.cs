using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1Shooting : MonoBehaviour {

    public GameObject bulletPrefab;
    private GameObject bulletPrefabClone;
    public GameObject bombPrefab;
    private GameObject bombPrefabClone;
    private bool intro = true;

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

        }
	}
}
