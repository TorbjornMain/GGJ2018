using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Controller {
	
	// Update is called once per frame
	void Update () {
        if (possessedPawn != null)
        {
            possessedPawn.UpdateMoveVector(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")));
            possessedPawn.UpdateCamVector(new Vector3(Input.GetAxis("MouseY"), Input.GetAxis("MouseX"), 0));
        }
    }
}
