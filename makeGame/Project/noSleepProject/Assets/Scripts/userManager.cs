using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Usable
{
    void Use(RaycastHit hit);
}

public class userManager : MonoBehaviour
{

    public static userManager Instance{get; private set;}

    public Camera securityRoom;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonUp(0))
        {
            
            Ray ray = securityRoom.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, 20.0f))
            {
                Usable temp = hit.collider.gameObject.GetComponent<Usable>();

                if(temp != null)
                {
                    temp.Use(hit);
                }
                // if(hit.collider == doorControlLeft)
                // {
                //     doorLeft.activateDoor();
                // }
                // if(hit.collider == doorControlRight)
                // {
                //     doorRight.activateDoor();
                // }
            }
        }
    }
}
