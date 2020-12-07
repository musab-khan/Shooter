using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    Animator anim;
    [SerializeField] float hitPoints;
    [SerializeField] Slider healthBar;
    float damageTaken;
    public UIManager UIManage;

    // Start is called before the first frame update
    private void Start()
    {
        healthBar.value = 1;
    }

    private void Update()
    {
        healthBar.value = HitPointsRemaining / hitPoints;
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
        StartCoroutine(deathWait());
    }

    IEnumerator deathWait()
    {
        anim.SetTrigger("Death");
        yield return new WaitForSeconds(4);
        Time.timeScale = 0;
        UIManage.EnablePanel();

    }
}
