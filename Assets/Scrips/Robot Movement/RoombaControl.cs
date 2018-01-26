using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoombaControl : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            transform.Rotate(0, speed * Time.deltaTime, 0);
        }

    }
    void FixedUpdate()
    {

    }
}
