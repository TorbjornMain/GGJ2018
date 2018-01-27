using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Controller {
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

	// Update is called once per frame
	void Update () {
        if (posessedPawn != null)
        {
            posessedPawn.UpdateMoveVector(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")));
            posessedPawn.UpdateCamVector(new Vector3(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0));
            if(Input.GetButtonDown("Fire2"))
            {
                SendMessage("DoPosess");
            }
        }
    }

    protected override IEnumerator posessPawn(Pawn target)
    {
        yield return base.posessPawn(target);
        if (target.cam)
        {
            target.cam.enabled = true;
            target.cam.GetComponent<AudioListener>().enabled = true;
        }
        
    }
    protected override void unposessPawn()
    {
        if (posessedPawn)
        {
            if (posessedPawn.cam)
            {
                posessedPawn.cam.enabled = false;
                posessedPawn.cam.GetComponent<AudioListener>().enabled = false;
            }
        }
        base.unposessPawn();
        
    }
}
