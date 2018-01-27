using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapNode : MonoBehaviour
{
    public Transform snapLocation;
    public List<GameObject> snappedObjects;
    void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Rigidbody>() && !other.GetComponent<Pawn>())
        {
            if (!snappedObjects.Contains(other.gameObject))
            {
                other.transform.position = snapLocation.position;
                other.transform.rotation = snapLocation.rotation;
                snappedObjects.Add(other.gameObject);
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (snappedObjects.Contains(other.gameObject))
        {
            snappedObjects.Remove(other.gameObject);
        }
    }
}
