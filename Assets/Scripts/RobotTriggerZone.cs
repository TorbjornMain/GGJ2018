using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotTriggerZone : MonoBehaviour
{
    public GameObject objectToTween;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Robot")
        {
            if (other.GetComponent<RoombaManager>() != null)
            {
                objectToTween.GetComponent<RobotTrigger>().Tween();
            }
        }
    }
}
