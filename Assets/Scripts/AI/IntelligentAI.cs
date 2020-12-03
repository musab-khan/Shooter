using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntelligentAI : EnemyAI
{
    public Transform[] PossibleHideouts;
    protected Transform target;
    float maxDistance = 1000f;
    public override Vector3 CalculateDestination()
    {
        foreach(Transform hideout in PossibleHideouts)
        {
            if (Vector3.Distance(hideout.position, transform.position) < maxDistance)
            {
                target = hideout;
                maxDistance = Vector3.Distance(hideout.position, transform.position);
            }
        }
        return target.position;
    }
}
