using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeOff : MonoBehaviour
{

    public float launchPower = 1.0f;   
   private Rigidbody rb;

   private void Start() 
   {

       rb = gameObject.GetComponent<Rigidbody>();

       rb.AddForce(rb.transform.forward * launchPower);




   }
}
