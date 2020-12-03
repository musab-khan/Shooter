using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : Destructable
{
    protected NavMeshAgent agent;
    public Transform[] PossibleTargets;
    protected Transform target;
    protected float NextState;
    Animator anim;
    private void Awake()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
        anim = gameObject.GetComponentInChildren<Animator>();
        target = PossibleTargets[Random.Range(0, PossibleTargets.Length)];
        anim.SetBool("isWalking", true);
        agent.SetDestination(target.position);
    }
    public override void Die()
    {
        base.Die();
        print("I died");
    }

    public override void TakeDamage(float amount)
    {
        base.TakeDamage(amount);
    }

}
