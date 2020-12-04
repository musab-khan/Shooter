using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    Animator anim;
    [SerializeField] float hitPoints;
    float damageTaken;
    public UIManager UIManage;

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

    void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }

    public void TakeDamage(float amount)
    {
        damageTaken += amount;
        if (HitPointsRemaining <= 0)
            Die();
    }

    public void Die()
    {
        anim.SetLayerWeight(1, 0);
        anim.SetTrigger("Death");
        Time.timeScale = 0;
        UIManage.EnablePanel();
    }
}
