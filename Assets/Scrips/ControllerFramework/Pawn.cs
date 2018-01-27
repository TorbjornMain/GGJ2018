﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : MonoBehaviour {

    public Vector3 MoveVector;
    public Vector3 CamVector;
    public Controller controller;
    public Camera cam;
    public int ID;

    protected virtual void Start()
    {
        ID = Random.Range(0, 999);
    }

    protected virtual void Update()
    {
        if(controller == null)
        {
            MoveVector = CamVector = Vector3.zero;
        }
    }
    public void UpdateMoveVector(Vector3 move)
    {
        MoveVector = move;
    }

    public void UpdateCamVector(Vector3 cam)
    {
        CamVector = cam;
    }

    public virtual void OnFire1()
    {

    }
}
