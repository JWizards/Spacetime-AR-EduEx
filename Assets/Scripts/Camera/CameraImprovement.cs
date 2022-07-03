using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class CameraImprovement : MonoBehaviour
{
    void Start()
    {
        var vuforia = VuforiaARController.Instance;
        vuforia.RegisterVuforiaStartedCallback(OnVuforiaStarted);
        
    }

    private void OnVuforiaStarted()
    {
        CameraDevice.Instance.SetFocusMode(
            CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);
 //     CameraDevice.Instance.SetFlashTorchMode(true);
    }
}
