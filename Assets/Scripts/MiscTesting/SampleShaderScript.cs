using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleShaderScript : MonoBehaviour
{
    public Material sampleShader;
    public int fresnelPower = 1;
 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        sampleShader.SetInt("_Fresnel_Power", fresnelPower);
    }
}
