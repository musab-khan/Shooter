using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Destructable
{
    public Transform crossHair;

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
