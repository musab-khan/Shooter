using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public float Vertical;
    public float Horizontal;
    public Vector2 MouseInput;
    public bool Fire1;
    FixedJoystick leftJoystick;
    FixedTouchField touchField;
    FixedButton shootBtn;
    public bool mobileControls = false;

    private void Awake()
    {
        leftJoystick = GameObject.Find("Fixed Joystick").GetComponent<FixedJoystick>();
        touchField = GameObject.Find("TouchField").GetComponent<FixedTouchField>();
        shootBtn = GameObject.Find("ShootButton").GetComponent<FixedButton>();
    }

    void Update()
    {
        if (!mobileControls)
        {
            Vertical = Input.GetAxis("Vertical");
            Horizontal = Input.GetAxis("Horizontal");
            MouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        }

        else
        {
            Vertical = leftJoystick.Vertical;
            Horizontal = leftJoystick.Horizontal;
            MouseInput = new Vector2(touchField.TouchDist.x, touchField.TouchDist.y);
        }
        Fire1 = shootBtn.Pressed;
    }
}
