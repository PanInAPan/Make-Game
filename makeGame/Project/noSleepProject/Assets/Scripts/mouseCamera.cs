﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseCamera : MonoBehaviour
{
    public Transform playerCam; 
    public int rotateSpeed, clampValue;
    public bool ADKeys, movingLeft, movingRight;
    public int targetFramerate;

    void Start()
    {
        Application.targetFrameRate = targetFramerate;
    }

    void Update()
    {
        if(ADKeys == true)
        {
            if (Input.GetKey(KeyCode.A))
            {
                if (playerCam.localRotation == Quaternion.Euler(0, -clampValue, 0))
                {

                }
                else
                {
                    playerCam.Rotate(0, -rotateSpeed, 0);
                }
            }
            if (Input.GetKey(KeyCode.D))
            {
                if (playerCam.localRotation == Quaternion.Euler(0, clampValue, 0))
                {

                }
                else
                {
                    playerCam.Rotate(0, rotateSpeed, 0);
                }
            }
        }
        if(ADKeys == false)
        {
            if(movingLeft == true)
            {
                if (playerCam.localRotation == Quaternion.Euler(0, -clampValue, 0))
                {

                }
                else
                {
                    playerCam.Rotate(0, -rotateSpeed, 0);
                }
            }
            if(movingRight == true)
            {
                if (playerCam.localRotation == Quaternion.Euler(0, clampValue, 0))
                {

                }
                else
                {
                    playerCam.Rotate(0, rotateSpeed, 0);
                }
            }
        }
    }
    public void rotateLeft()
    {
        movingLeft = true;
    }
    public void rotateRight()
    {
        movingRight = true;
    }
    public void stopRotateLeft()
    {
        movingLeft = false;
    }
    public void stopRotateRight()
    {
        movingRight = false;
    }
}