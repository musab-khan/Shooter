using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testCrosshair : MonoBehaviour
{
    float lookHeight;
    public float maxAngle;
    public float minAngle;
    InputController controller;

    private void Awake()
    {
        controller = GameManager.Instance.InputController;
    }

    public void LookHeight(float value)
    {
        //lookHeight += value;
        //Debug.Log(lookHeight);

        //if (lookHeight > maxAngle || lookHeight < minAngle)
        //    lookHeight -= value;

        transform.position = new Vector3(controller.MouseInput.x, controller.MouseInput.y, 0);
    }
}
