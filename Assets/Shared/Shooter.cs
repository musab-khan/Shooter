using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] float rateOfFire = 0.3f;
    [SerializeField] Projectile projectile;
    [SerializeField] Transform hand;
    [SerializeField] Transform aimTarget;

    //[HideInInspector]
    public Transform muzzle;

    float nextFireAllowed;
    public bool canFire;

    private void Awake()
    {
       // muzzle = transform.Find("Muzzle");
        transform.SetParent(hand);
        //aimTarget = GameObject.Find("Crosshair").transform;
    }

    public virtual void Fire()
    {
        canFire = false;

        if (Time.time < nextFireAllowed)
            return;

        nextFireAllowed = Time.time + rateOfFire;

        //muzzle.LookAt(aimTarget);
        Instantiate(projectile, muzzle.position, muzzle.rotation);

        canFire = true;
        
    }

    //private void Update()
    //{
    //    Ray ray = Camera.main.ScreenPointToRay();
    //    RaycastHit hitInfo;

    //    if (Physics.Raycast(ray, out hitInfo))
    //    {
    //        if (hitInfo.collider.tag.Equals("Enemy"))
    //            Debug.Log("hit enemy");

    //    }
    //}

}
