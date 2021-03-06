﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float TimeToLeave;
    [SerializeField] float damage;

    private void Start()
    {
        Destroy(gameObject, TimeToLeave);
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            var health = other.gameObject.GetComponent<EnemyHealth>();
            health.TakeDamage(damage);
        }     
    }
}
