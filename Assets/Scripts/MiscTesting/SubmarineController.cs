using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmarineController : MonoBehaviour
{
   public float speed = 5f;
   public float rotationSpeed = 360f;

   void FixedUpdate()
    {
        bool forward = Input.GetButton("Vertical");
        float rotAboutY = Input.GetAxis("Mouse X");
        float rotAboutX = Input.GetAxis("Mouse Y");

        ApplyRot(rotAboutY, rotAboutX);
    }

    void ApplyRot(float Y, float X)
    {
        transform.Rotate(-1*X*rotationSpeed*Time.deltaTime, Y*rotationSpeed*Time.deltaTime, 0);

    }
}
