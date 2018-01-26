using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour {

    public GameObject[] Triggerables;
    void OpenThings()
    {
        foreach (var item in Triggerables)
        {
            item.SendMessage("Trigger");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Moveable")
        {
            LeanTween.moveLocalY(gameObject, -0.12f, 1).setEaseOutQuad().setOnComplete(OpenThings);
            
        }
    }
}
