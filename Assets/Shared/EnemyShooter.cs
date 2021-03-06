﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    [SerializeField] float rateOfFire = 0.3f;
    [SerializeField] ProjectileEnemy projectile;
    [SerializeField] Transform aimTarget;

    public Transform muzzle;
    float nextFireAllowed;
    public bool canFire;
    PlayerHealth playerHealth;

    private void Start()
    {
        playerHealth = aimTarget.GetComponent<PlayerHealth>();
    }

    public void Fire()
    {
        if (playerHealth.isAlive)
        {
            canFire = false;

            if (Time.time < nextFireAllowed)
                return;

            nextFireAllowed = Time.time + rateOfFire;
            muzzle.LookAt(aimTarget.position + new Vector3(0, 1, 0));
            Instantiate(projectile, muzzle.position, muzzle.rotation);

            canFire = true;
        }
    }
}
