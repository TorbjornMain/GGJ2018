using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapNode : MonoBehaviour
{
    public Transform snapLocation;
    void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Rigidbody>() && !other.GetComponent<Pawn>())
        {
            other.transform.position = snapLocation.position;
            other.transform.rotation = snapLocation.rotation;
        }
    }
}
