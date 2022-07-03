using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    private string moveInputAxis = "Vertical";
    private string turnInputAxis = "Horizontal";
    private string jumpKey = "Jump";
    private string CrouchKey = "Fire3";

    public float rotationSpeed = 360;


    private float moveAxisForward = 0;
    private float moveAxisLeft = 0;
    private float moveAxisRight = 0;

    public float speed = 10;

    void Update()
    {
        
        float turnAxis = moveAxisRight - moveAxisLeft;
        float verticalInput = Input.GetAxis(jumpKey) - Input.GetAxis(CrouchKey);


        ApplyInput(moveAxisForward, turnAxis, verticalInput);

    }





    void ApplyInput(float moveInput, float turnInput, float verticalInput)
    {
        Move(moveInput, verticalInput);
        Turn(turnInput);
    }

    void Move(float input, float vertical)
    {
        transform.Translate(Vector3.forward * speed * input);
        transform.Translate(Vector3.up * speed * vertical);
    }

    void Turn(float input)
    {
        transform.Rotate(0, input * rotationSpeed * Time.deltaTime, 0);

    }





    public void ButtonTriggerForwardInputDown()
    {        
        moveAxisForward = 1;
    }

    public void ButtonTriggerForwardInputUp()
    {
        moveAxisForward = 0;
    }

    public void ButtonTriggerLeftInputDown()
    {
        moveAxisLeft = 1;
    }

    public void ButtonTriggerLeftInputUp()
    {
        moveAxisLeft = 0;
    }

    public void ButtonTriggerRightInputDown()
    {
        moveAxisRight = 1;
    }

    public void ButtonTriggerRightInputUp()
    {
        moveAxisRight = 0;
    }
}
