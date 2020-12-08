using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class testCrosshair : MonoBehaviour
{
    public float maxPos;
    public float minPos;
    InputController controller;
    public float senstivity;
    public float yPos;
    public Transform muzzle;
    int layerMask;
    bool isLocked = false;
    public GameObject normalCrossHair;
    public GameObject lockedCrossHair;

    private void Awake()
    {
        layerMask = 1 << 11;
        layerMask = ~layerMask;
        controller = GameManager.Instance.InputController;
    }

    private void Update()
    {
        if (isLocked)
        {
            normalCrossHair.SetActive(false);
            lockedCrossHair.SetActive(true);
        }
        else
        {
            normalCrossHair.SetActive(true);
            lockedCrossHair.SetActive(false);
        }

       
        yPos = Mathf.Clamp(transform.position.y + controller.MouseInput.y * senstivity, minPos, maxPos);   
        transform.position = new Vector3(transform.position.x, yPos, transform.position.z);

        Vector3 direction = transform.position - muzzle.position;

        Ray ray = new Ray(muzzle.position, direction);
        RaycastHit hitInfo;

        Debug.DrawRay(muzzle.position, direction);
        if (Physics.Raycast(ray, out hitInfo, 200f, layerMask))
        {
            if (hitInfo.collider.tag == "Enemy")
            {
                isLocked = true;
            }
            else
                isLocked = false;
        }


    }
}
