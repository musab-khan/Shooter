using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : Destructable
{
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
