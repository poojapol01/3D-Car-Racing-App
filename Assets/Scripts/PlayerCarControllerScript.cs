using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCarControllerScript : MonoBehaviour
{
    [Header("Wheels Collider")]
    public WheelCollider frontLeftWheelCollider;
    public WheelCollider frontRightWheelCollider;
    public WheelCollider rearLeftWheelCollider;
    public WheelCollider rearRightWheelCollider;

    [Header("Wheels Transform")]
    public Transform frontLeftWheelTransform;
    public Transform frontRightWheelTransform;
    public Transform rearLeftWheelTransform;
    public Transform rearRightWheelTransform;

    [Header("Car Engine")]
    public float accelerationForce = 300f;
    public float breakingForce = 300f;
    private float presentBreakForce = 0f;
    private float presentAcceleration = 0f;

    private void Update(){
        MoveCar();
    }

    private void MoveCar()
    {
        //All Wheels Drive
        frontLeftWheelCollider.motorTorque = presentAcceleration;
        frontRightWheelCollider.motorTorque = presentAcceleration;
        rearLeftWheelCollider.motorTorque = presentAcceleration;
		rearRightWheelCollider.motorTorque = presentAcceleration;
        
        presentAcceleration = accelerationForce * Input.GetAxis("Vertical");
    }

}
