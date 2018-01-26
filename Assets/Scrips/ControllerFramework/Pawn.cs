using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : MonoBehaviour {

    public Vector3 MoveVector;
    public Vector3 CamVector;
    public Controller controller;
    public void UpdateMoveVector(Vector3 move)
    {
        MoveVector = move;
    }

    public void UpdateCamVector(Vector3 cam)
    {
        CamVector = cam;
    }
}
