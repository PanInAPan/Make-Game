using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animatronic : MonoBehaviour
{

    [System.Serializable]
    public enum Actions
    {
        TPose = 0,
        Stage,
        Standing,
        OutsideCamera,
        OutsideWindow,
        OutsideDoor,
        Kill
    }

    [System.Serializable]
    public struct AnimatronicNodeData
    {
        public node node;
        public bool weight;
        public Actions action;
    }

    public node startLocation;

    [SerializeField]
    node currentLocation;

    public AnimatronicNodeData[] nodeData;
    public Dictionary<string, AnimatronicNodeData> nodeName2Data;

    // Start is called before the first frame update
    void Start()
    {
        nodeName2Data = new Dictionary<string, AnimatronicNodeData>();

        for(int i = 0; i < nodeData.Length; i++)
        {
            nodeName2Data[nodeData[i].node.name] = nodeData[i];
        }

        currentLocation = startLocation;
        this.gameObject.transform.position = currentLocation.gameObject.transform.position;
        this.gameObject.transform.rotation = currentLocation.gameObject.transform.rotation;
    }

    public void Transition()
    {
        node[] outgoingNodes = currentLocation.nodes;

        List<AnimatronicNodeData> validNodes = new List<AnimatronicNodeData>();

        for(int i = 0; i < outgoingNodes.Length; i++)
        {
            AnimatronicNodeData temp = nodeName2Data[outgoingNodes[i].name];
            if(temp.weight == true)
            {
                validNodes.Add(temp);
            }
        }

        if(validNodes.Count > 0)
        {
            int travelToIndex = Random.Range(0, validNodes.Count);

            currentLocation = validNodes[travelToIndex].node;

            this.gameObject.transform.position = currentLocation.gameObject.transform.position;
            this.gameObject.transform.rotation = currentLocation.gameObject.transform.rotation;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
