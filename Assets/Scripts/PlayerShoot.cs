using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] Shooter assaultrifle;

    private void Update()
    {
        if (GameManager.Instance.InputController.Fire1)
        {
            assaultrifle.Fire();
        }
    }
}
