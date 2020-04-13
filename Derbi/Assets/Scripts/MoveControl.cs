using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MoveControl : MonoBehaviour
{
    public FloatingJoystick joystick;
    public Transform centerOfMass;

    public WheelCollider WheelFL;
    public WheelCollider WheelFR;
    public WheelCollider WheelRL;
    public WheelCollider WheelRR;


    public Transform WheelFLtrans;
    public Transform WheelFRtrans;
    public Transform WheelRLtrans;
    public Transform WheelRRtrans;

    public float motorTorque = 100f;
    public float maxsteer = 20f;
    private Rigidbody rigidbody;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.centerOfMass = centerOfMass.localPosition;
    }

    private void FixedUpdate()
    {
        WheelRL.motorTorque = joystick.Vertical * motorTorque;
        WheelRR.motorTorque = joystick.Vertical * motorTorque;
        WheelFR.steerAngle = joystick.Horizontal * maxsteer;
        WheelFL.steerAngle = joystick.Horizontal * maxsteer;
    }


}


   