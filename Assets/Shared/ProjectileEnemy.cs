using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ProjectileEnemy : MonoBehaviour
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
        if (other.gameObject.tag == "Player")
        {
            var health = other.gameObject.GetComponent<PlayerHealth>();
            health.TakeDamage(damage);
        }     
    }
}
