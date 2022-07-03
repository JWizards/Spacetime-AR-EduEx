using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcherULite : MonoBehaviour
{
   
    public Camera sceneCamera;
    public Camera arCamera;
    public GameObject spaceTime;

    public bool isAR = true;


    public void SwitchCameras()
    {
        if (isAR)
        {
            //sceneCamera.rect = new Rect(0, 0, 1f, 1f);
            //arCamera.rect = new Rect(0, 0, 0f, 0f);
            sceneCamera.gameObject.SetActive(true);
            spaceTime.SetActive(true);
            isAR = false;
        }

        else
        { 
            //arCamera.rect = new Rect(0, 0, 1f,1f);
            //sceneCamera.rect = new Rect(0, 0, 0f, 0f);
            sceneCamera.gameObject.SetActive(false);
            spaceTime.SetActive(false);
            isAR = true;
        }
    }
}
