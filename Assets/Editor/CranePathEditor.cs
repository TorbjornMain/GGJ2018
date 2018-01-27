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

        Event evt = Event.current;
        Rect contextRect = new Rect(10, 10, 100, 100);
        if (evt.type == EventType.ContextClick)
        {
            Vector2 mousePos = evt.mousePosition;
            if (contextRect.Contains(mousePos))
            {
                EditorUtility.DisplayPopupMenu(new Rect(mousePos.x, mousePos.y, 0, 0), "Assets/", null);
                evt.Use();
            }
        }


    }

    public override void OnInspectorGUI()
    {
      
    }

}
