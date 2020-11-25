﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    [SerializeField] float hitPoints;

    public event System.Action OnDeath;
    public event System.Action OnDamageRecieved;

    float damageTaken; 
    
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
    
    public virtual void Die()
    {
        if (!isAlive)
            return;

        if (OnDeath != null)
            OnDeath();
    }

    public virtual void TakeDamage(float amount)
    {
        damageTaken += amount;
        if (OnDamageRecieved != null)
            OnDamageRecieved();

        if (HitPointsRemaining <= 0)
            Die();
    }

    public void Reset()
    {
        damageTaken = 0;
    }
}
