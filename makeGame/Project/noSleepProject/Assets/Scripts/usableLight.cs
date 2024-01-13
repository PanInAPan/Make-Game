using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class usableLight : powered, Usable
{

    public Light light;

    public override void onPowerOutage()
    {
        light.enabled = false;
        this.enabled = false;
    }

    public void Use(RaycastHit hit)
    {

        if(this.enabled)
        {
            light.enabled = !light.enabled;

            if(light.enabled)
            {
                powerManager.Instance.UsePower(this);
            }
            else
            {
                powerManager.Instance.ReleasePower(this);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        light.enabled = false;
        wattage = 0.2f;
    }
}
