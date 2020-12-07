using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public static PlayerAnimation AnimationController;
    public Animator anim;
    void Awake()
    {
        if (AnimationController == null)
        {
            AnimationController = this;
        }


        else if (AnimationController != this)
        {
            Destroy(gameObject);
        }
        anim = GetComponentInChildren<Animator>();

        AdsManager.ReviveEvent += onRevive;
    }

    private void OnDisable()
    {
        AdsManager.ReviveEvent -= onRevive;
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("Vertical", GameManager.Instance.InputController.Vertical);
        anim.SetFloat("Horizontal", GameManager.Instance.InputController.Horizontal);
    }

    public void onDeath()
    {
        Debug.Log("Death amnimation");
        anim.SetTrigger("Death");
    }

    public void onRevive()
    {
        anim.SetTrigger("Revived");
        anim.SetLayerWeight(1, 1);
        Time.timeScale = 1;
    }
}
