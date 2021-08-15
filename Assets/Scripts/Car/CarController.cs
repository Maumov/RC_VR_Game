using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    PlayerInputs playerInputs;

    [SerializeField] float horizontalInput;
    [SerializeField] float verticalInput;
    private float currentSteeringAngle;
    private float currentBrakeForce;
    private bool isBreaking;


    [SerializeField] private float motorForce;
    [SerializeField] private float brakeForce;
    [SerializeField] private float maxSteeringAngle;

    [SerializeField] private WheelCollider frontLeftWheelCollider;
    [SerializeField] private WheelCollider frontRightWheelCollider;
    [SerializeField] private WheelCollider backLeftWheelCollider;
    [SerializeField] private WheelCollider backRightWheelCollider;

    [SerializeField] private Transform frontLeftWheelTransform;
    [SerializeField] private Transform frontRightWheelTransform;
    [SerializeField] private Transform backLeftWheelTransform;
    [SerializeField] private Transform backRightWheelTransform;

    private void Start() {
        playerInputs = GetComponent<PlayerInputs>();
    }

    private void FixedUpdate() {
        HandleMotor();
        HandleSteering();
        UpdateWheels();
    }

    public void SetHorizontalInputClamped(float value) {
        horizontalInput = Mathf.Clamp(value, -maxSteeringAngle, maxSteeringAngle);
        horizontalInput /= maxSteeringAngle;
    }

    public void SetHorizontalInput(float value) {
        horizontalInput = value;
    }
    public void SetVerticalInput(float value) {
        verticalInput = value;
    }
    public void SetIsBreaking(bool value) {
        isBreaking = value;
    }
    public void ResetCar() {
        transform.rotation = Quaternion.AngleAxis(0f, Vector3.zero);
    }


    void HandleMotor() {
        frontLeftWheelCollider.motorTorque = verticalInput * motorForce;
        frontRightWheelCollider.motorTorque = verticalInput * motorForce;
        backLeftWheelCollider.motorTorque = verticalInput * motorForce;
        backRightWheelCollider.motorTorque = verticalInput * motorForce;

        currentBrakeForce = isBreaking ? brakeForce : 0f;
        ApplyBraking();
        //if(isBreaking) {
            
        //} else {
            
        //}
    }

    void ApplyBraking() {
        frontLeftWheelCollider.brakeTorque = currentBrakeForce;
        frontRightWheelCollider.brakeTorque = currentBrakeForce;
        //backLeftWheelCollider.brakeTorque = currentBrakeForce;
        //backRightWheelCollider.brakeTorque = currentBrakeForce;
    }

    void HandleSteering() {
        currentSteeringAngle = maxSteeringAngle * horizontalInput;
        frontLeftWheelCollider.steerAngle = currentSteeringAngle;
        frontRightWheelCollider.steerAngle = currentSteeringAngle;
    }

    void UpdateWheels() {
        UpdateSingleWheel(frontLeftWheelCollider, frontLeftWheelTransform);
        UpdateSingleWheel(frontRightWheelCollider, frontRightWheelTransform);
        UpdateSingleWheel(backLeftWheelCollider, backLeftWheelTransform);
        UpdateSingleWheel(backRightWheelCollider, backRightWheelTransform);
    }

    void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform) {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.rotation = rot;
        wheelTransform.position = pos;
    }
}
