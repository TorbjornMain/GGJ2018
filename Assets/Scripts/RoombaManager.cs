using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RoombaManager : MonoBehaviour
{
	public Transform target;
	private NavMeshAgent agent;
    private bool isActive;
	
	// Use this for initialization
	void Start ()
	{
		agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		agent.SetDestination(target.localPosition);

        if (Input.GetMouseButtonDown(0))
        {
            Ray toMouse = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit rhInfo;
            bool didHit = Physics.Raycast(toMouse, out rhInfo, 500f);

            if (didHit)
            {
                target.gameObject.transform.position = rhInfo.point;
            }
        }
    }
}
