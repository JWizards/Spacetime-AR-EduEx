using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    
    public Camera sceneCamera;
    public Camera arCamera;
    public GameObject spaceTime;

    public bool isAR = false;

    void Start()
    {
        arCamera.enabled = false;
    }


    public void SwitchCameras()
    {
        if (isAR)
        {
            sceneCamera.enabled = true;
            arCamera.enabled = false;
            spaceTime.SetActive(true);
            isAR = false;
        }

        else
        {
            sceneCamera.enabled = false;
            arCamera.enabled = true;
            spaceTime.SetActive(false);
            isAR = true;
        }
    }

}
