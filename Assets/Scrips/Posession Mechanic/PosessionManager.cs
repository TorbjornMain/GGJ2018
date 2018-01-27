﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct UIWidgetPosition
{
    public int ID;
    public Vector3 screenSpacePosition;
    public bool isPossessable;
    public float distance;
}


[RequireComponent(typeof(PlayerController))]
public class PosessionManager : MonoBehaviour {
    public Pawn[] levelPawns;
    public List<UIWidgetPosition> WidgetPositions;
    public float PosessionRange = 10000;
    public float PosessionFOV = 5;
    PlayerController pc;
    bool posess = false;
    // Use this for initialization
	void Awake () {
        levelPawns = FindObjectsOfType<Pawn>();
        pc = GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
        WidgetPositions = new List<UIWidgetPosition>();
        if(pc.posessedPawn)
        {
            if(pc.posessedPawn.cam)
            {
                Transform camTransform = pc.posessedPawn.cam.transform;
                foreach (var item in levelPawns)
                {
                    if (item == pc.posessedPawn)
                        continue;
                    if(Vector3.Dot(camTransform.forward, (item.transform.position - camTransform.position).normalized) > Mathf.Cos(pc.posessedPawn.cam.fieldOfView * Mathf.Deg2Rad / 2) && Vector3.Magnitude(item.transform.position - camTransform.position) < PosessionRange)
                    {
                        RaycastHit rc = new RaycastHit();
                        ReplacementShaderScript rp;
                        if((rp = pc.posessedPawn.cam.GetComponent<ReplacementShaderScript>()) != null)
                        {
                            if(rp.shaderActive)
                            {
                                if (!Physics.Raycast(camTransform.position, (item.transform.position - camTransform.position).normalized, out rc, (item.transform.position - camTransform.position).magnitude, LayerMask.GetMask("Metal")))
                                {
                                    UIWidgetPosition wp = new UIWidgetPosition();
                                    wp.ID = item.ID;
                                    wp.distance = (item.transform.position - camTransform.position).magnitude;
                                    wp.isPossessable = Vector3.Dot(camTransform.forward, (item.transform.position - camTransform.position).normalized) > Mathf.Cos(PosessionFOV * Mathf.Deg2Rad / 2);
                                    wp.screenSpacePosition = pc.posessedPawn.cam.WorldToViewportPoint(item.transform.position);
                                    if(wp.isPossessable && posess)
                                    {
                                        pc.PosessPawn(item);
                                        posess = false;
                                        return;
                                    }
                                    WidgetPositions.Add(wp);
                                }
                            }
                            else
                            {
                                if (!Physics.Raycast(camTransform.position, (item.transform.position - camTransform.position).normalized, out rc, (item.transform.position - camTransform.position).magnitude))
                                {
                                    UIWidgetPosition wp = new UIWidgetPosition();
                                    wp.ID = item.ID;
                                    wp.distance = (item.transform.position - camTransform.position).magnitude;
                                    wp.isPossessable = Vector3.Dot(camTransform.forward, (item.transform.position - camTransform.position).normalized) > Mathf.Cos(PosessionFOV * Mathf.Deg2Rad / 2);
                                    wp.screenSpacePosition = pc.posessedPawn.cam.WorldToViewportPoint(item.transform.position);
                                    if (wp.isPossessable && posess)
                                    {
                                        pc.PosessPawn(item);
                                        posess = false;
                                        return;
                                    }
                                    WidgetPositions.Add(wp);
                                }
                                else if(rc.collider.transform.root.gameObject == item.gameObject)
                                {
                                    UIWidgetPosition wp = new UIWidgetPosition();
                                    wp.ID = item.ID;
                                    wp.distance = (item.transform.position - camTransform.position).magnitude;
                                    wp.isPossessable = Vector3.Dot(camTransform.forward, (item.transform.position - camTransform.position).normalized) > Mathf.Cos(PosessionFOV * Mathf.Deg2Rad / 2);
                                    wp.screenSpacePosition = pc.posessedPawn.cam.WorldToViewportPoint(item.transform.position);
                                    if (wp.isPossessable && posess)
                                    {
                                        pc.PosessPawn(item);
                                        posess = false;
                                        return;
                                    }
                                    WidgetPositions.Add(wp);
                                }
                            }
                        }
                        else
                        {
                            if (!Physics.Raycast(camTransform.position, (item.transform.position - camTransform.position).normalized, out rc, (item.transform.position - camTransform.position).magnitude))
                            {
                                UIWidgetPosition wp = new UIWidgetPosition();
                                wp.ID = item.ID;
                                wp.distance = (item.transform.position - camTransform.position).magnitude;
                                wp.isPossessable = Vector3.Dot(camTransform.forward, (item.transform.position - camTransform.position).normalized) > Mathf.Cos(PosessionFOV * Mathf.Deg2Rad / 2);
                                wp.screenSpacePosition = pc.posessedPawn.cam.WorldToViewportPoint(item.transform.position);
                                if (wp.isPossessable && posess)
                                {
                                    pc.PosessPawn(item);
                                    posess = false;
                                    return;
                                }
                                WidgetPositions.Add(wp);
                            }
                            else if (rc.collider.transform.root.gameObject == item.gameObject)
                            {
                                UIWidgetPosition wp = new UIWidgetPosition();
                                wp.ID = item.ID;
                                wp.distance = (item.transform.position - camTransform.position).magnitude;
                                wp.isPossessable = Vector3.Dot(camTransform.forward, (item.transform.position - camTransform.position).normalized) > Mathf.Cos(PosessionFOV * Mathf.Deg2Rad / 2);
                                wp.screenSpacePosition = pc.posessedPawn.cam.WorldToViewportPoint(item.transform.position);
                                if (wp.isPossessable && posess)
                                {
                                    pc.PosessPawn(item);
                                    posess = false;
                                    return;
                                }
                                WidgetPositions.Add(wp);
                            }
                        }
                    }
                }
            }
        }

        posess = false;
	}

    void DoPosess()
    {
        posess = true;
    }
}
