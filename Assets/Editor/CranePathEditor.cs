using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(CranePath))]
public class CranePathEditor : Editor
{
    private void OnSceneGUI()
    {
        var path = (CranePath)target;
        foreach (var node in path.nodes)
        {
            EditorGUI.BeginChangeCheck();
            Vector3 newTargetPosition = Handles.PositionHandle(node.position, Quaternion.identity);
            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(target, "move");
                node.position = newTargetPosition;
            }
        }

    }

    public override void OnInspectorGUI()
    {
        var path = (CranePath)target;
        if (GUILayout.Button("Add Node"))
        {
            path.nodes.Add(new Node() { position = path.nodes.Count > 0 ? path.nodes[path.nodes.Count - 1].position : Vector3.zero });
        }
        DrawDefaultInspector();
    }

}
