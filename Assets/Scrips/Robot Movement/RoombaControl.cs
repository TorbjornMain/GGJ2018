using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoombaControl : MonoBehaviour
{
    public float turnRate = 1;
    Rigidbody rb;
    public float moveSpeed;
    public float fallSpeed;
    bool grounded;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        rb.SweepTest(transform.forward, out hit, Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime);
        if (!hit.collider)
        {
            transform.Translate(transform.forward * Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime, Space.World);
            transform.Rotate(0, Input.GetAxis("Horizontal") * turnRate * Time.deltaTime, 0);
        }
        else
        {

        }



    }
    void FixedUpdate()
    {

    }
}
