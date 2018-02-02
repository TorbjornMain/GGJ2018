using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteratctionManager : MonoBehaviour {
    public GameObject StoredRobot;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0))
        {
            Ray toMouse = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit rhInfo;
            bool didHit = Physics.Raycast(toMouse, out rhInfo, 500f);

            if(didHit)
            {
                Debug.Log(rhInfo.collider.name);
                rhInfo.collider.gameObject.SendMessage("Trigger");
            }
        }
	}
}
