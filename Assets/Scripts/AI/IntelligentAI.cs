using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntelligentAI : EnemyAI
{
    public Transform[] PossibleHideouts;
    public Transform[] ShootSpots;
    int hideoutIndex = 0;
    public Transform target;
    float maxDistance = 1000f;
    float attackDistance = 50f;
    float goBackTime = 5f;

    public override Transform CalculateDestination()
    {
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

    public override void ShootLogic()
    {
        if (agent.velocity == Vector3.zero)
        {
            isAware = false;
            anim.SetBool("isWalking", false);
            intelligent = true;
        }
    }

    public override void IntelligentSearch()
    {
        if (Vector3.Distance(player.transform.position, transform.position) < attackDistance)
        {
            Debug.Log(target.GetChild(0).name);
            anim.SetBool("isWalking", true);
            agent.SetDestination(target.GetChild(0).transform.position);
            if (agent.velocity == Vector3.zero)
            {
                transform.LookAt(player.transform.position);
                anim.SetBool("isWalking", false);
                shooter.Fire();
                anim.SetTrigger("shoot");
            }
        }
    }


}
