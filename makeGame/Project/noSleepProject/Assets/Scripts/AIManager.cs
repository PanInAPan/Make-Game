using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIManager : MonoBehaviour
{
    public static AIManager Instance;

    public node[] nodes;

    public animatronic[] animatronics;

    void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        nodes = FindObjectsOfType<node>();
        animatronics = FindObjectsOfType<animatronic>();
    }

    public void TransitionOccured()
    {
        Debug.Log("AI Manager: Transition Occured");

        for(int i = 0; i < animatronics.Length; i++)
        {
            animatronics[i].Transition();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
