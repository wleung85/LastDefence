using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour {

    public Animator bodyAnimator;
    public Animator armAnimator;
    public int invulnerableTime = 3;
    private bool invulnerable = false;
    private float invulnerableStartTime;

    void OnCollisionEnter2D (Collision2D collisionInfo)
    {
        if (!invulnerable)
        {
            if (collisionInfo.collider.tag.Equals("EnemyProjectile"))
            {
                GameObject.Find("Canvas").GetComponent<upgradesDummy>().hitHealth();
                MakeInvulnerable();
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collisionInfo)
    {
        if (!invulnerable)
        {
            if (collisionInfo.tag.Equals("EnemyProjectile"))
            {
                GameObject.Find("Canvas").GetComponent<upgradesDummy>().hitHealth();
                MakeInvulnerable();
            }
        }
    }

    private void Update()
    {
        if (invulnerable)
        {
            if (Time.time - invulnerableStartTime >= invulnerableTime)
            {
                MakeVulnerable();
            }
        }
    }

    private void MakeInvulnerable()
    {
        invulnerableStartTime = Time.time; 
        invulnerable = true;
        bodyAnimator.SetBool("BodyInvulnerable", true);
        armAnimator.SetBool("ArmInvulnerable", true);
    }

    private void MakeVulnerable()
    {
        invulnerable = false;
        bodyAnimator.SetBool("BodyInvulnerable", false);
        armAnimator.SetBool("ArmInvulnerable", false);
    }
}
