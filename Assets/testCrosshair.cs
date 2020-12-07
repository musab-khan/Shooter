using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testCrosshair : MonoBehaviour
{
    Vector2 aimposition;

    public void aimtarget(Vector2 input)
    {
        aimposition = input;
    }
    void Update()
    {
        transform.position = aimposition ;
    }
}
