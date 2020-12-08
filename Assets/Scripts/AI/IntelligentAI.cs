using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntelligentAI : EnemyAI
{
    public Transform[] PossibleHideouts;
    int hideoutIndex = 0;
    Transform target;
    float maxDistance = 1000f;
    float attackDistance = 50f;
    float goBackTime = 5f;
    float attackAllowed;


    public override Transform CalculateDestination()
    {
        intelligent = true;
        foreach(Transform hideout in PossibleHideouts)
        {
            if (Vector3.Distance(hideout.position, transform.position) < maxDistance)
            {
                target = hideout;
                maxDistance = Vector3.Distance(hideout.position, transform.position);
                break;
            }
        }
        return target;
    }

    public override void EnemyBehaviour()
    {
        if (agent.velocity == Vector3.zero)
        {
            isAware = false;
            anim.SetBool("isWalking", false);
        }
    }

    public override void IntelligentSearch()
    {
        isAware = false;

        if (Vector3.Distance(player.transform.position, transform.position) < attackDistance)
        {
            anim.SetBool("isWalking", true);
            agent.SetDestination(target.GetChild(0).transform.position);
            if (agent.velocity == Vector3.zero)
            {
                transform.LookAt(player.transform.position);

                RaycastHit hit;
                if (Physics.Raycast(transform.position + new Vector3(0, 1.0f, 0f), transform.forward, out hit))
                {
                    Debug.DrawRay(transform.position + new Vector3(0, 1.0f, 0f), transform.forward);
                    if (hit.collider.CompareTag("Player"))
                    {
                        anim.SetBool("isWalking", false);
                        shooter.Fire();
                        anim.SetTrigger("shoot");
                    }
                }
            }
        }

        else
            agent.SetDestination(target.position);
    }

    public override void NotAware()
    {
        base.NotAware();
        intelligent = false;
    }

}
