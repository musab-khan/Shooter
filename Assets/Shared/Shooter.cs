using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] float rateOfFire = 0.3f;
    [SerializeField] Projectile projectile;
    [SerializeField] Transform hand;
    [SerializeField] Transform aimTarget;

    [SerializeField] CrossHair crossHair;
    [SerializeField] ParticleSystem flash;

    //[HideInInspector]
    public Transform muzzle;

    float nextFireAllowed;
    public bool canFire;

    private void Awake()
    {
        transform.SetParent(hand);
    }

    public virtual void Fire()
    {
        canFire = false;

        if (Time.time < nextFireAllowed)
            return;

        nextFireAllowed = Time.time + rateOfFire;
        Debug.DrawRay(muzzle.position, crossHair.rayDirection);
        muzzle.LookAt(crossHair.rayDirection);
        flash.Play();
        Instantiate(projectile, muzzle.position, muzzle.rotation);

        canFire = true;
        
    }
}
