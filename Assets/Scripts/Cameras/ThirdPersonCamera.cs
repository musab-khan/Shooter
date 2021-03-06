﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    [SerializeField] Vector3 cameraOffset;
    [SerializeField] float damping;
    public Transform cameraLookTarget;
    public Player localPlayer;

    void Start()
    {
        //GameManager.Instance.OnLocalPlayerJoined += HandleOnLocalPlayerJoined;
        //Debug.Log(cameraLookTarget);
        //Debug.Log(localPlayer);
    }

    void HandleOnLocalPlayerJoined (Player player)
    {
        localPlayer = player;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = cameraLookTarget.position + 
            localPlayer.transform.forward * cameraOffset.z + localPlayer.transform.up * cameraOffset.y + 
            localPlayer.transform.right * cameraOffset.x;

        Quaternion targetRotation = Quaternion.LookRotation(cameraLookTarget.position - targetPosition, Vector3.up);
        transform.position = Vector3.Lerp(transform.position, targetPosition, damping * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, damping * Time.deltaTime);
    }
}
