using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpportunityController : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;

    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";
    private bool isBreaking;
    private float currentBreakForce;
    private float steeringAngle;

    public WheelCollider frontLCollider, frontRCollider, middleLCollider, middleRCollider, backLCollider, backRCollider;
    public Transform frontLTransform, frontRTransform, middleLTransform, middleRTransform, backLTransform, backRTransform;
    public float motorForce, breakForce, maxSteeringAngle, currentSteerAngle;
    public Transform head;


    private void FixedUpdate()
    {
        GetInput();
        HandleMotor();
        HandleSteering();
        UpdateWheels();
    }

    void GetInput()
    {
        horizontalInput = Input.GetAxis(HORIZONTAL);
        verticalInput = Input.GetAxis(VERTICAL);
    }

    void HandleMotor()
    {
        frontLCollider.motorTorque = verticalInput * motorForce;
        frontRCollider.motorTorque = verticalInput * motorForce;
        breakForce = isBreaking ? breakForce : 0f;
        if (isBreaking)
        {
            ApplyBreaking();
        }
        
    }

    private void ApplyBreaking()
    {
        frontRCollider.brakeTorque = currentBreakForce;
        frontLCollider.brakeTorque = currentBreakForce;
        middleLCollider.brakeTorque = currentBreakForce;
        middleRCollider.brakeTorque = currentBreakForce;
        backRCollider.brakeTorque = currentBreakForce;
        backLCollider.brakeTorque = currentBreakForce;
    }

    private void HandleSteering()
    {
        currentSteerAngle = maxSteeringAngle * horizontalInput;
        frontLCollider.steerAngle = currentSteerAngle;
        frontRCollider.steerAngle = currentSteerAngle;
    }

    private void UpdateWheels()
    {
        UpdateSingleWheel(frontLCollider, frontLTransform);
        UpdateSingleWheel(frontRCollider, frontRTransform);
        UpdateSingleWheel(middleLCollider, middleLTransform);
        UpdateSingleWheel(middleRCollider, middleRTransform);
        UpdateSingleWheel(backLCollider, backLTransform);
        UpdateSingleWheel(backRCollider, backRTransform);
      
    }

    private void UpdateSingleWheel(WheelCollider WheelCollider, Transform WheelTransform)
    {
        Vector3 pos;
        Quaternion rot;
        WheelCollider.GetWorldPose(out pos, out rot);
        WheelTransform.rotation = rot;
        WheelTransform.position = pos;
    } 
}
