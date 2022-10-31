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

    [Header("Car Steering")]
	public float wheelsTorque = 35f;
	private float presentTurnAngle = 0f;

    private void Update(){
        MoveCar();
        CarSteering();
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

    private void CarSteering(){
		presentTurnAngle = wheelsTorque * Input.GetAxis("Horizontal");
		
		frontLeftWheelCollider.steerAngle = presentTurnAngle;
		frontRightWheelCollider.steerAngle = presentTurnAngle;

        SteeringWheels(frontLeftWheelCollider, frontLeftWheelTransform);
		SteeringWheels(frontRightWheelCollider, frontRightWheelTransform);
		SteeringWheels(rearLeftWheelCollider, rearLeftWheelTransform);
		SteeringWheels(rearRightWheelCollider, rearRightWheelTransform);
	}

    private void SteeringWheels(WheelCollider wCollider, Transform wTransform){
		Vector3 position;
		Quaternion rotation;
		
		wCollider.GetWorldPose(out position, out rotation);
		
		wTransform.position = position;
		wTransform.rotation = rotation;
	}
}
