using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPawn : Pawn {

    public float maxPitch, minPitch, maxYaw, minYaw, sensitivity;
    Vector3 baseAng, addAng;

    protected override void Start()
    {
        base.Start();
        baseAng = transform.rotation.eulerAngles;
        addAng = Vector3.zero;
    }


    // Update is called once per frame
    void Update () {
        addAng += CamVector * Time.deltaTime * sensitivity;
        addAng.x *= -1;
        transform.rotation = Quaternion.Euler(baseAng + addAng);
	}
}
