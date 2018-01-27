using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Crane : Pawn
{
    public GameObject cranePart;


    // Use this for initialization
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        NavMeshHit hit;
        if (NavMesh.SamplePosition(cranePart.transform.position + MoveVector * Time.deltaTime, out hit, 1, 0))
        {
            cranePart.GetComponent<NavMeshAgent>().nextPosition = cranePart.transform.position + MoveVector * Time.deltaTime;
        }

    }
}
