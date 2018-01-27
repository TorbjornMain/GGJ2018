using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CranePath : MonoBehaviour
{

    public List<Node> nodes = new List<Node>();
    public List<PathNode> nodeConnections = new List<PathNode>();
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
[System.Serializable]
public class Node
{
    public Vector3 position;
}
[System.Serializable]

public class PathNode
{
    public Node start, end;
}