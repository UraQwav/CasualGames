using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MoveControl : MonoBehaviour
{
    public FloatingJoystick joystick;
    public WheelCollider WheelFL;
    public WheelCollider WheelFR;
    public WheelCollider WheelRL;
    public WheelCollider WheelRR;
    public Transform WheelFLtrans;
    public Transform WheelFRtrans;
    public Transform WheelRLtrans;
    public Transform WheelRRtrans;
    public Vector3 eulertest;
    private bool braked = false;
    public float maxBrakeTorque = 2000f;
    private Rigidbody rb;
    public Transform centreofmass;
    public float maxTorque = 2000f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = centreofmass.transform.localPosition;
    }

    void FixedUpdate()
    {
        if (!braked)
        {
            WheelFL.brakeTorque = 0;
            WheelFR.brakeTorque = 0;
            WheelRL.brakeTorque = 0;
            WheelRR.brakeTorque = 0;
        }
        //speed of car, Car will move as you will provide the input to it.

        WheelRR.motorTorque = maxTorque * joystick.Vertical;
        WheelRL.motorTorque = maxTorque * joystick.Vertical;

        //changing car direction
        //Here we are changing the steer angle of the front tyres of the car so that we can change the car direction.
        WheelFL.steerAngle = 30 * (joystick.Horizontal);
        WheelFR.steerAngle = 30 * joystick.Horizontal;
    }
    void Update()
    {
        HandBrake();

        //for tyre rotate
        WheelFLtrans.Rotate(WheelFL.rpm / 60 * maxTorque * Time.deltaTime, 0, 0);
        WheelFRtrans.Rotate(WheelFR.rpm / 60 * maxTorque * Time.deltaTime, 0, 0);
        WheelRLtrans.Rotate(WheelRL.rpm / 60 * maxTorque * Time.deltaTime, 0, 0);
        WheelRRtrans.Rotate(WheelRL.rpm / 60 * maxTorque * Time.deltaTime, 0, 0);
        //changing tyre direction
        Vector3 temp = WheelFLtrans.localEulerAngles;
        Vector3 temp1 = WheelFRtrans.localEulerAngles;
        temp.y = WheelFL.steerAngle - (WheelFLtrans.localEulerAngles.z);
        WheelFLtrans.localEulerAngles = temp;
        temp1.y = WheelFR.steerAngle - WheelFRtrans.localEulerAngles.z;
        WheelFRtrans.localEulerAngles = temp1;
        eulertest = WheelFLtrans.localEulerAngles;
    }
    void HandBrake()
    {
        //Debug.Log("brakes " + braked);
        if (Input.GetButton("Jump"))
        {
            braked = true;
        }
        else
        {
            braked = false;
        }
        if (braked)
        {

            WheelRL.brakeTorque = maxBrakeTorque * 20;//0000;
            WheelRR.brakeTorque = maxBrakeTorque * 20;//0000;
            WheelRL.motorTorque = 0;
            WheelRR.motorTorque = 0;
        }
    }
    //public float speed;
    //public FloatingJoystick joystick;
    //public Rigidbody rb;

    //public void FixedUpdate()
    //{
    //    Vector3 direction = Vector3.forward * joystick.Vertical + Vector3.right * joystick.Horizontal;
    //    rb.AddForce(direction * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);
    //}
}