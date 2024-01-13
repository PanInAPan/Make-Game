using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class usableSecurityDoorManager : powered, Usable
{
    public float doorHeight = 2.253f;
    public float doorSpeed = 1.0f;

    protected bool doorInUse = false;
    protected bool doorOpen = false;

    public Transform door;

    IEnumerator openDoor()
    {
        powerManager.Instance.ReleasePower(this);

        for(float amount = 2.253f; amount < doorHeight; amount += doorSpeed * Time.deltaTime)
        {
            Debug.Log("Opening Door" + amount.ToString());
            door.position = new Vector3(door.position.x, amount, door.position.z);
            yield return null;
        }

        door.position = new Vector3(door.position.x, doorHeight, door.position.z);

        doorInUse = false;
        doorOpen = true;
    }
    IEnumerator closeDoor()
    {

        powerManager.Instance.UsePower(this);
        
        for(float amount = doorHeight; amount > 2.253f; amount -= doorSpeed * Time.deltaTime)
        {
            Debug.Log("Closing Door" + amount.ToString());
            door.position = new Vector3(door.position.x, amount, door.position.z);
            yield return null;
        }

        door.position = new Vector3(door.position.x, 2.253f, door.position.z);
        
        doorInUse = false;
        doorOpen = false;
    }

    void Start()
    {
        doorOpen = true;
        wattage = 0.5f;
    }

    public void Use(RaycastHit hit)
    {
        if(!doorInUse && this.enabled)
        {
            Debug.Log("Left Door");
            doorInUse = true;
            if(doorOpen)
                StartCoroutine("closeDoor");
            else
                StartCoroutine("openDoor");
        }
    }

    public override void onPowerOutage()
    {
        if(doorOpen == false)
        {
            StartCoroutine("openDoor");
        }

        this.enabled = false;
    }
}
