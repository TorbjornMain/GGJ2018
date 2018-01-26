using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour {
    public GameObject vent;
    void OpenVent()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Moveable")
        {
            vent.SendMessage("Trigger");
        }
    }
}
