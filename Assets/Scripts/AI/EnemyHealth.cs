using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints;
    float damageTaken;

    // Start is called before the first frame update

    public float HitPointsRemaining
    {
        get
        {
            return hitPoints - damageTaken;
        }
    }

    public bool isAlive
    {
        get
        {
            return HitPointsRemaining > 0;
        }
    }

    public void TakeDamage(float amount)
    {
        damageTaken += amount;
        if (HitPointsRemaining <= 0)
            Die();
    }

    public void Die()
    {
        Destroy(gameObject);
    }

}
