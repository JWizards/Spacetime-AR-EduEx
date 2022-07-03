using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BenderTag : MonoBehaviour
{

    public Rigidbody rb;
    Vector3 CentrePos;


    public static List<BenderTag> Benders;

    void OnEnable()
    {
        if (Benders == null)
            Benders = new List<BenderTag>();
        Benders.Add(this);
    }

    void OnDisable()
    {
        Benders.Remove(this);
    }

    void Start()
    {
        CentrePos = rb.position;
    }
    
}
