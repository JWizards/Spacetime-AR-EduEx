using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    public Rigidbody rb;
 //   public bool Enable;
    public static List<Gravity> Bodies;
    public static float G = .125f;
    

private void Start() 
{
    rb = gameObject.GetComponent<Rigidbody>();
}


    void OnEnable()


    {
        Debug.Log("Gravitational object enabled");
        if (Bodies == null)
        {
            Bodies = new List<Gravity>();
        }
        Bodies.Add(this);
    }


    void onDisable()
    {
        Debug.Log("Object Disabled.");
        Bodies.Remove(this);
    }

  
    void FixedUpdate()

    {
        //  Gravity[] Bodies = FindObjectsOfType<Gravity>();

       // if (Enable)
        {
            foreach (Gravity body in Bodies)
            {
                if (body != this)
                    Attract(body);
            }
        }
    }

   
    void Attract(Gravity objToAttract)
    {
        Rigidbody rbToAttract = objToAttract.rb;

        Vector3 direction = rb.position - rbToAttract.position;
        float distance = direction.sqrMagnitude;
        if (distance == 0f)
        {
            Debug.Log("returned");
                return;
        }

        float forceMagnitude = (G * rb.mass * rbToAttract.mass) / distance;
        Vector3 Force = direction.normalized * forceMagnitude;

        rbToAttract.AddForce(Force);

    }

    public static void DestroyList()
    {
        Bodies = new List<Gravity>();
    }


}    
