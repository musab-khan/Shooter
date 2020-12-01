﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponReloader : MonoBehaviour
{
    [SerializeField] int maxAmmo;
    [SerializeField] float reloadTime;
    [SerializeField]int clipSize;

    int ammo;
    int shotsFiredInClip;
    bool isReloading;

    public int RoundsRemainingInClip
    {
        get
        {
            return clipSize - shotsFiredInClip;
        }
    }

    public bool IsReloading
    {
        get
        {
            return IsReloading;
        }
    }

    public void Reload()
    {
        if (isReloading)
            return;

        isReloading = true;
    }

    private void ExecuteReload()
    {
        isReloading = false;
        ammo -= shotsFiredInClip;
        shotsFiredInClip = 0;

        if (ammo < 0)
        {
            ammo = 0;
            shotsFiredInClip += -ammo;
        }
    }

}
