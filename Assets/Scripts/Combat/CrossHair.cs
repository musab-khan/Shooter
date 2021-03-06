﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossHair : MonoBehaviour
{
    [SerializeField] Texture2D normalTarget;
    [SerializeField] Texture2D lockedTarget;
    
    [SerializeField] int size;
    [SerializeField] float maxAngle;
    [SerializeField] float minAngle;

    public Vector2 crossPos;
    float lookHeight;
    Texture2D currentTexture;
    int layerMask;

    bool isLocked = false;

    public Vector3 rayPoint;

    public Transform muzzle;

    private void Awake()
    {
        layerMask = 1 << 11;
        layerMask = ~layerMask;
    }
    public void LookHeight(float value)
    {
        lookHeight += value;

        if (lookHeight > maxAngle || lookHeight < minAngle)
            lookHeight -= value;
    } 

    private void OnGUI()
    {
        if (isLocked)
            currentTexture = lockedTarget;
        else
            currentTexture = normalTarget;

        Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position - new Vector3(2,0,0));
        screenPosition.y = Screen.height - screenPosition.y;

        crossPos = new Vector2(screenPosition.x, screenPosition.y - lookHeight);
        GUI.DrawTexture(new Rect(screenPosition.x, screenPosition.y - lookHeight, size, size), currentTexture);
    }

    private void FixedUpdate()
    {
        isLocked = false;

        Vector2 rayDirection = new Vector2(crossPos.x, Screen.height - crossPos.y);
        Ray ray = Camera.main.ScreenPointToRay(rayDirection);
        RaycastHit hit; 

        if (Physics.Raycast(ray, out hit, 300f, layerMask))
        {
            rayPoint = hit.point;
            if (hit.collider.tag == "Enemy")
            {
                isLocked = true;
            }

        }
    }

}
