using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleController : MonoBehaviour
{
    private string moveInputAxis = "Vertical";
    private string turnInputAxis = "Horizontal";
    private string jumpKey = "Jump";
    private string CrouchKey = "Fire3";

    public float rotationSpeed = 360;

    public float speed = 10;

    void Update()
    {
        float moveAxis = Input.GetAxis(moveInputAxis);
        float turnAxis = Input.GetAxis(turnInputAxis);
        float verticalInput = Input.GetAxis(jumpKey) - Input.GetAxis(CrouchKey);


        ApplyInput(moveAxis, turnAxis, verticalInput);

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

}
