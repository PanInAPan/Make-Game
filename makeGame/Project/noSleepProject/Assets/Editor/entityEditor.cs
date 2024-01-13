using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(animatronic))]
public class entityEditor : Editor
{
    public override void OnInspectorGUI()
    {
        animatronic animatronicScript = (animatronic)target;

        animatronicScript.startLocation = (node) EditorGUILayout.ObjectField("Starting Node:", animatronicScript.startLocation, typeof(node), true);

        AIManager[] aiManager = Resources.FindObjectsOfTypeAll<AIManager>();    

        if(aiManager == null)
        {
            EditorGUILayout.HelpBox("Scene must have an AI Manager to populate nodes.", MessageType.Error);
        }
        else
        {
            node[] nodes = aiManager[0].nodes;

            if(animatronicScript.nodeData == null || animatronicScript.nodeData.Length != nodes.Length)
            {
                animatronicScript.nodeData = new animatronic.AnimatronicNodeData[nodes.Length];
                for(int i = 0; i < nodes.Length; i++)
                {
                    animatronicScript.nodeData[i] = new animatronic.AnimatronicNodeData();
                }
            }

            EditorGUILayout.BeginVertical();

            for(int i = 0; i < nodes.Length; i++)
            {
                EditorGUILayout.BeginHorizontal();

                EditorGUILayout.TextArea(nodes[i].name);

                animatronicScript.nodeData[i].node = nodes[i];
                animatronicScript.nodeData[i].action = (animatronic.Actions)EditorGUILayout.EnumPopup(animatronicScript.nodeData[i].action);
                animatronicScript.nodeData[i].weight = EditorGUILayout.Toggle(animatronicScript.nodeData[i].weight);

                EditorGUILayout.EndHorizontal();
            }

            EditorGUILayout.EndVertical();

        }
    }
}
