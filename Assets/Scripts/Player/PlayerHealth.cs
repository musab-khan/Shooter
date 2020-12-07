using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    Animator anim;
    [SerializeField] float hitPoints;
    [SerializeField] Slider healthBar;
    float HitPointsRemaining;
    public UIManager UIManage;

    void Awake()
    {
        healthBar.value = 1;
        HitPointsRemaining = hitPoints;
        AdsManager.ReviveEvent += RestoreHealth;
        anim = GetComponentInChildren<Animator>();
    }

    private void OnDisable()
    {
        AdsManager.ReviveEvent -= RestoreHealth;
    }


    private void Update()
    {
        healthBar.value = HitPointsRemaining / hitPoints;
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
        HitPointsRemaining -= amount;
        if (HitPointsRemaining <= 0)
        {
            Die();
            HitPointsRemaining = 0;
        }
            
    }

    public void Die()
    {
        Debug.Log("I died");
        anim.SetLayerWeight(1, 0);
        StartCoroutine(deathWait());
    }

    IEnumerator deathWait()
    {
        PlayerAnimation.AnimationController.onDeath();
        yield return new WaitForSeconds(4);
        Time.timeScale = 0;
        UIManage.EnableADpanel();
    }

    public void RestoreHealth()
    {
        HitPointsRemaining = hitPoints;
    }
}
