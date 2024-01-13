using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerManager : MonoBehaviour
{

    public static powerManager Instance{get; private set;}

    float powerSink = 0.08f;
    public float Charge{get; private set;}
    protected powered[] poweredObjects;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        Charge = 101.0f;
        poweredObjects = FindObjectsOfType<powered>();
    }

    // void OnGUI()
    // {
    //     GUILayout.Label(Charge.ToString());
    // }

    // Update is called once per frame
    void Update()
    {
        Charge -= powerSink * Time.deltaTime;

        if(Charge <= 0.0f)
        {
            Charge = 0.0f;

            foreach(var poweredItem in poweredObjects)
            {
                poweredItem.onPowerOutage();
            }
            this.enabled = false;
        }
    }

    public void UsePower(powered poweredObjects)
    {
        powerSink += poweredObjects.wattage;
    }

    public void ReleasePower(powered poweredObjects)
    {
        powerSink -= poweredObjects.wattage;
    }

}
