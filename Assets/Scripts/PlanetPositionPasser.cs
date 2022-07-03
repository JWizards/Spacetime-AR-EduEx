using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetPositionPasser : MonoBehaviour
{
    //This script passes the position of the planet to the shader graph
    //Currently only works with a single planet
    //The plan is to use custom arrays to create an array of planets, and apply the same physics used

    public GameObject[] planets;

    public string[] propertyName;

    private Vector3[] planetPositions;
    private float[] planetMasses;
    public Material spaceTimeMat;


    void Start()
    {
        planetPositions = new Vector3[planets.Length];
        planetMasses = new float[planets.Length];
        for(int i = 0; i < planets.Length ; i++)
        {
            Rigidbody rb = planets[i].GetComponent<Rigidbody>();
            planetMasses[i] = rb.mass;
         
        }
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < planets.Length ; i++)
        {
            if (planets[i].activeSelf)
            {
                planetPositions[i] = planets[i].transform.position;
            Vector4 planetVector4 = new Vector4(planetPositions[i].x, planetPositions[i].y,
             planetPositions[i].z, planetMasses[i]);
            
            spaceTimeMat.SetVector(propertyName[i], planetVector4);

            }

            else
            {
                spaceTimeMat.SetVector(propertyName[i], new Vector4(0, 0, 0, 0));
            }
            
        }
    }
    
}
