using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator anim;
    void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("Vertical", GameManager.Instance.InputController.Vertical);
        anim.SetFloat("Horizontal", GameManager.Instance.InputController.Horizontal);
    }
}
