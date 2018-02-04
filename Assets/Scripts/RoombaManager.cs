using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RoombaManager : MonoBehaviour
{
	public GameObject target;
    public GameObject targetPrefab;
	private NavMeshAgent agent;
    public InteratctionManager playerManager;

    [SerializeField]
    private bool isMoving = false;
    [Space(2)]
    [Header("Mat Management")]
    public GameObject colourObject1;
    public GameObject colourObject2;
    [SerializeField]
    private Material baseColour;
    public Material selected;


    // Use this for initialization
    void Start ()
	{
		agent = GetComponent<NavMeshAgent>();
        baseColour = colourObject1.GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update ()
	{
        if (playerManager.activeRobot == gameObject)
        {
            colourObject1.GetComponent<Renderer>().material = selected;
            colourObject2.GetComponent<Renderer>().material = selected;
        }
        if(playerManager.activeRobot != gameObject)
        {
            colourObject1.GetComponent<Renderer>().material = baseColour;
            colourObject2.GetComponent<Renderer>().material = baseColour;
        }

        if(target != null)
        {
            if (isMoving)
            {
                agent.SetDestination(target.transform.localPosition);
            }

            if (target.transform.position.x == gameObject.transform.position.x && target.transform.position.z == gameObject.transform.position.z)
            {
                Destroy(target.gameObject);
                isMoving = false;
            }
        }
        

        if (Input.GetMouseButtonDown(0) && playerManager.activeRobot == gameObject)
        {
            
            Ray toMouse = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit rhInfo;
            bool didHit = Physics.Raycast(toMouse, out rhInfo, 500f);
            
            if (didHit && rhInfo.collider.tag == "Ground")
            {
                isMoving = true;
                if (target == null)
                {
                    target = GameObject.Instantiate(targetPrefab, rhInfo.point, new Quaternion());
                }
                target.gameObject.transform.position = rhInfo.point;
            }
            if(didHit && rhInfo.collider.tag == "RobotTrigger")
            {
                isMoving = true;
                if(target == null)
                {
                    target = GameObject.Instantiate(targetPrefab, rhInfo.collider.GetComponent<RobotTrigger>().zone.transform.position, new Quaternion());
                }
                target.gameObject.transform.position = rhInfo.collider.GetComponent<RobotTrigger>().zone.transform.position;
            }
        }
    }
}
