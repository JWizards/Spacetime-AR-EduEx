﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;

 
    void FixedUpdate()
    {
        transform.position = target.position;
        transform.rotation = target.rotation;
    }
}
