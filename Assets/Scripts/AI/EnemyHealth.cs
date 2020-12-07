using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] Slider healthBar;
    [SerializeField] float hitPoints;
    float damageTaken;

    // Start is called before the first frame update

    private void Start()
    {
        healthBar.value = 1;
    }

    private void Update()
    {
        healthBar.value = HitPointsRemaining / hitPoints;
        healthBar.transform.LookAt(Camera.main.transform);
    }
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
