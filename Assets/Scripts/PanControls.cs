using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanControls : MonoBehaviour
{

    Vector3 touchStart;
    public Camera controlledCamera;
    Transform cameraTransform;

    public float scale;
    public float threshhold;
    public float angularSpeedFactor;
    private Vector3 rotateValue;


    public float angularSmoothSpeed;
    public float inertia;
    private Touch TA;
    private Vector3 angleDirection;
    private Vector3 smoothedAngleDirection;

    private Touch T0;
    private Touch T1;
    private Vector3 forwardDirection;
    private Vector3 smoothedForwardDirection;
    public float pullFactorScale;
    public float forwardSmoothSpeed;
    public float forwardSpeed;

    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("START");
            touchStart = controlledCamera.ScreenToViewportPoint(Input.mousePosition);
           // Debug.Log(controlledCamera.ScreenToViewportPoint(Input.mousePosition));
        }

        if (Input.GetMouseButton(0) && Input.touchCount != 2)
        {
            TA = Input.GetTouch(0);


            if (TA.deltaPosition.magnitude * angularSpeedFactor >= threshhold)
                angleDirection = (touchStart - controlledCamera.ScreenToViewportPoint(Input.mousePosition) + angleDirection);
            else
                touchStart = controlledCamera.ScreenToViewportPoint(Input.mousePosition); 
        }

        if (Input.touchCount == 2)
        {
            T0 = Input.GetTouch(0);
            T1 = Input.GetTouch(1);

            Vector2 T0PrevPos = T0.position - T0.deltaPosition;
            Vector2 T1PrevPos = T1.position - T1.deltaPosition;

            Vector2 TPrevPos = T1PrevPos - T0PrevPos;
            Vector2 TPos = T1.position - T0.position;
  
            float pullFactor = pullFactorScale * (TPos.magnitude - TPrevPos.magnitude);
    
            forwardDirection = cameraTransform.forward*pullFactor;
        }


        LerpAngle();
        LerpForward();

    }


    void LerpAngle()
    {
        smoothedAngleDirection = Vector3.Lerp(Vector3.zero, angleDirection, angularSmoothSpeed);
        angleDirection = inertia * (angleDirection - smoothedAngleDirection);

        smoothedAngleDirection = angularSpeedFactor * smoothedAngleDirection;


        //the below is to acount for how eulerAngles is defined.. I do not know how.. purely experimental.
        rotateValue = new Vector3(-1 * smoothedAngleDirection.y, smoothedAngleDirection.x, 0);

        cameraTransform.eulerAngles = cameraTransform.eulerAngles + scale * rotateValue;
    }

    void LerpForward()
    {
        smoothedForwardDirection = forwardSpeed * Vector3.Lerp(Vector3.zero, forwardDirection, forwardSmoothSpeed);
        forwardDirection = inertia * (forwardDirection - smoothedForwardDirection);

        cameraTransform.position = cameraTransform.position + smoothedForwardDirection;

    }
    
}
