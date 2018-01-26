using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoombaControl : Pawn
{
    public float turnRate = 1;
    Rigidbody rb;
    public float moveSpeed;
    public float fallSpeed;
    bool grounded;
    // Use this for initialization
    protected override void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        rb.useGravity = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (grounded)
        {
            rb.transform.Rotate(0, MoveVector.x * turnRate * Time.deltaTime, 0);
            Vector3 targetVelocity = new Vector3(0, 0, MoveVector.z);
            targetVelocity = transform.TransformDirection(targetVelocity);
            targetVelocity *= moveSpeed;
            Vector3 velocity = rb.velocity;
            Vector3 velocityChange = (targetVelocity - velocity);
            velocityChange.x = Mathf.Clamp(velocityChange.x, -10, 10);
            velocityChange.z = Mathf.Clamp(velocityChange.z, -10, 10);
            velocityChange.y = 0;
            rb.AddForce(velocityChange, ForceMode.VelocityChange);
        }
        rb.AddForce(new Vector3(0, -9.8f * rb.mass, 0));

        grounded = false;
    }
    void OnCollisionStay(Collision collision)
    {
        grounded = true;
        //float yRot = transform.eulerAngles.y;

        //Vector3 normal = new Vector3();
        //foreach (var point in collision.contacts)
        //{
        //    normal += point.normal;
        //}
        //normal /= collision.contacts.Length;
        ////transform.rotation = Quaternion.LookRotation(Vector3.Cross(transform.right, normal));
        //RaycastHit hit2;
        //if (Physics.Raycast(transform.position, -(transform.up), out hit2))
        //{
        //    transform.rotation = Quaternion.LookRotation(Vector3.Cross(transform.right, hit2.normal));
        //}
    }
}
