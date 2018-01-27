using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ForkLiftControl : Pawn
{
    public List<AxleInfo> axleInfos; // the information about each individual axle
    public float maxMotorTorque; // maximum torque the motor can apply to wheel
    public float maxSteeringAngle; // maximum steer angle the wheel can have
    public Transform centerOfMass;
    List<Collider> ProngsTouching = new List<Collider>();
    public Transform parentingPoint;
    Rigidbody pickUpAble;
    GameObject holding;
    float holdingMass;
    Rigidbody rb;
    public GameObject fork;
    public float forkLow = 0.379f, forkHigh = 1.203f;
    public float forkSpeed = 1f;
    protected override void Start()
    {
        base.Start();
        axleInfos[0].leftWheel.ConfigureVehicleSubsteps(1, 15, 18);
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = centerOfMass.localPosition;
    }
    public void FixedUpdate()
    {
        float motor = maxMotorTorque * MoveVector.z;
        float steering = maxSteeringAngle * MoveVector.x;

        foreach (AxleInfo axleInfo in axleInfos)
        {
            if (axleInfo.steering)
            {
                axleInfo.leftWheel.steerAngle = steering;
                axleInfo.rightWheel.steerAngle = steering;
            }
            if (axleInfo.motor)
            {
                axleInfo.leftWheel.motorTorque = motor;
                axleInfo.rightWheel.motorTorque = motor;
            }
            axleInfo.leftWheel.brakeTorque = maxMotorTorque - Mathf.Abs(motor);
            axleInfo.rightWheel.brakeTorque = maxMotorTorque - Mathf.Abs(motor);
        }

    }
    public void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (pickUpAble && !holding)
            {
                ProngsTouching.Clear();
                holding = pickUpAble.gameObject;
                holdingMass = holding.GetComponent<Rigidbody>().mass;
                Destroy(holding.GetComponent<Rigidbody>());
                holding.transform.position += holding.transform.up * .01f;
                holding.transform.parent = parentingPoint;
            }
            else if (holding)
            {
                ProngsTouching.Clear();
                holding.AddComponent(typeof(Rigidbody));
                holding.GetComponent<Rigidbody>().mass = holdingMass;
                holdingMass = 0;
                holding.transform.parent = null;
                holding = null;

            }
        }
        float newY = fork.transform.localPosition.y + CamVector.x * forkSpeed * Time.deltaTime;
        if (newY > forkLow && newY < forkHigh)
        {
            fork.transform.localPosition = new Vector3(fork.transform.localPosition.x, newY, fork.transform.localPosition.z);
        }


    }
    void OnTriggerEnter(Collider other)
    {
        if (ProngsTouching.Contains(other))
        {
            if (other.GetComponent<Rigidbody>())
            {
                pickUpAble = other.GetComponent<Rigidbody>();
            }
        }
        ProngsTouching.Add(other);
    }
    void OnTriggerExit(Collider other)
    {
        ProngsTouching.Remove(other);
        if (pickUpAble == other.GetComponent<Rigidbody>())
        {
            pickUpAble = null;
        }
    }
}

[System.Serializable]
public class AxleInfo
{
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public bool motor; // is this wheel attached to motor?
    public bool steering; // does this wheel apply steer angle?
}