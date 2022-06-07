using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CamMovement : MonoBehaviour
{

    public CamSwitch CamStatus;

    [Range(0.1f, 20.0f), Tooltip("Used to control the speed of the camera when filming")]
        public float CameraSpeed = 0.3f;

    // the input sources that can control the kart
    private float turnInput = 0;

    void Awake()
    {}

    // Update is called once per frame
    void Update()
    {
        if(!CamStatus.topViewCamera) {
            turnInput = Input.GetAxis("Horizontal");
            transform.Rotate(0, turnInput*CameraSpeed, 0, Space.Self);
        }
    }
}