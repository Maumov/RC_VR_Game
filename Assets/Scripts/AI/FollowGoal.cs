using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowGoal : MonoBehaviour
{
    public Transform goal;
    CarController carController;
    float acceleration = 5f;
    float deceleration = 5f;
    float minSpeed = 0.0f;
    float maxSpeed = 10f;
    float brakeAngle = 20f;
    float rotSpeed = 1f;
    float speed = 0f;

    
    private void Start() {
        carController = GetComponent<CarController>();
    }

    private void LateUpdate() {
        
        Vector3 lookAtGoal = new Vector3(goal.position.x,
                                        transform.position.y,
                                        goal.position.z);
        Vector3 direction = lookAtGoal - transform.position;

        float angle = Vector3.SignedAngle(direction, transform.forward,Vector3.up);
        //Debug.Log(angle);
        carController.SetHorizontalInputClamped(-angle);
        //transform.rotation = Quaternion.Slerp(transform.rotation,
        //                                      Quaternion.LookRotation(direction),
        //                                      Time.deltaTime * rotSpeed);


        //Debug.Log(Vector3.Angle(goal.forward, transform.forward) > brakeAngle && speed > 0.1f);
        if(Vector3.Angle(goal.forward,transform.forward) > brakeAngle && speed > 0.1f) {
            carController.SetVerticalInput(-1f);
            carController.SetIsBreaking(true);
            //speed = Mathf.Clamp(speed - (deceleration * Time.deltaTime), minSpeed, maxSpeed);
        } else {
            carController.SetVerticalInput(1f);
            carController.SetIsBreaking(false);
            //speed = Mathf.Clamp(speed + (acceleration * Time.deltaTime), minSpeed, maxSpeed);
        }
        //transform.Translate(0f, 0f, speed * Time.deltaTime);
    }
}
