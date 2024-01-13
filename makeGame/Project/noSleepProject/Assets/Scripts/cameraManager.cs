using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraManager : MonoBehaviour
{
    public Camera securityGuard;
    public Camera camera_1;
    public Camera camera_2;
    public Camera camera_3;
    public Camera camera_4;
    public Camera camera_5;
    public Camera camera_6;

    protected Camera[] cameras;

    protected float[] cameraWatchTime;

    protected int currentCamera;

    void Awake()
    {
        cameras = new Camera[7];

        cameras[0] = securityGuard;
        cameras[1] = camera_1;
        cameras[2] = camera_2;
        cameras[3] = camera_3;
        cameras[4] = camera_4;
        cameras[5] = camera_5;
        cameras[6] = camera_6;

        cameraWatchTime = new float[cameras.Length];

        for(int i = 0; i < cameras.Length; i++)
        {
            cameraWatchTime[i] = 0.0f;
        }
    }

    void incCamera()
    {
        cameras[currentCamera].enabled = false;

        currentCamera++;

        if(currentCamera >= cameras.Length)
        {
            currentCamera = 0;
        }

        cameras[currentCamera].enabled = true;
    }

    void decCamera()
    {
        cameras[currentCamera].enabled = false;

        currentCamera--;

        if(currentCamera < 0)
        {
            currentCamera = cameras.Length-1;
        }

        cameras[currentCamera].enabled = true;
    }

    void UpdateCameraWatchTime()
    {
        for(int i = 0; i < cameras.Length; i++)
        {
            if(i == currentCamera)
            {
                Debug.Log("Active Camera " + i.ToString() + ": " + cameraWatchTime[i].ToString());
                cameraWatchTime[i] = 0.0f;
                continue;
            }
            Debug.Log("Camera " + i.ToString() + ": " + cameraWatchTime[i].ToString());
            cameraWatchTime[i] += Time.deltaTime;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.UpArrow))
        {
            incCamera();
        }

        if(Input.GetKeyUp(KeyCode.DownArrow))
        {
            decCamera();
        }
        UpdateCameraWatchTime();
    }
}
