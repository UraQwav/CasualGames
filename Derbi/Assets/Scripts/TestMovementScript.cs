using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class AxleInfo
{
    public WheelCollider leftWheel;
    public GameObject leftWheelVisuals;
    private bool leftGrounded = false;
    private float travelL = 0f;
    private float leftAckermanCorrectionAngle = 0;
    public WheelCollider rightWheel;
    public GameObject rightWheelVisuals;
    private bool rightGrounded = false;
    private float travelR = 0f;
    private float rightAckermanCorrectionAngle = 0;
    public bool motor;
    public bool steering;

    public float Antiroll = 10000;
    private float AntrollForce = 0;

    public float ackermanSteering = 1f;
    
    public void CalculateAndApplySteering(AxleInfo axleInfo, float speed, float maxSteeringAngle)
    {
        axleInfo.leftWheel.steerAngle = 30 * speed;
        axleInfo.rightWheel.steerAngle = 30 * speed;
    }
   
   
}
[RequireComponent(typeof(Rigidbody))]
public class TestMovementScript : MonoBehaviour
{
    public List<AxleInfo> axleInfos;
    public float maxMotorTorque;
    public float maxSteeringAngle;
    private Rigidbody body;
    public FloatingJoystick FloatingJoystick;

    private void Start()
    {
        body = GetComponent<Rigidbody>();
    }
    /*public float GetHorizontal()
    {
        if(gameObject.transform.rotation.y > 180)
        {
            
        }
    }*/
   
    public void FixedUpdate()
    {
        float motor = maxMotorTorque * FloatingJoystick.Vertical;
        foreach (AxleInfo axleInfo in axleInfos)
        {
            if (axleInfo.steering)
            {
                axleInfo.CalculateAndApplySteering(axleInfo,FloatingJoystick.Horizontal,maxSteeringAngle);
            }
            if (axleInfo.motor)
            {
                axleInfo.leftWheel.motorTorque = motor;
                axleInfo.rightWheel.motorTorque = motor;
            }
            
           
        }
    }
}