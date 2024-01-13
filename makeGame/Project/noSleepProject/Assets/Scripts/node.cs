using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class node : MonoBehaviour
{
    public node[] nodes;

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;

        if(nodes != null && nodes.Length > 0)
        {
            for(int i = 0; i < nodes.Length; i++)
            {
                Gizmos.DrawLine(this.gameObject.transform.position, nodes[i].gameObject.transform.position);
            }
        }
    }
}
