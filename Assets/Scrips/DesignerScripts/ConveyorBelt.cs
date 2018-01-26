using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour {
    public BoxCollider moveArea;
    public Vector3 direction;
    public float speed;
    private Renderer rend;
    private float offset;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag=="Robot" || other.tag == "Moveable")
        {
            other.gameObject.transform.Translate(direction*Time.deltaTime*speed);
        }
    }

    private void Start()
    {
        rend = GetComponent<Renderer>();    
    }

    private void Update()
    {
        offset += Time.deltaTime * speed*0.5f/*the half is because the belt indicator's tiling is x2 */;
        rend.material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
    }
}
