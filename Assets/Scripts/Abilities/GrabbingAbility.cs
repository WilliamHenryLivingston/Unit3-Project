using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbingAbility : MonoBehaviour
{

    [SerializeField] private Transform holdingHand;
    [SerializeField] private float syncStrength;
    private Rigidbody objectInHold;
    public void PickUpObject(Rigidbody toGrab)
    {
       if(objectInHold != null)
        {

            DropObject();
            return;
        }
        
        objectInHold = toGrab;
        toGrab.useGravity = false;
        toGrab.drag = 10;
        toGrab.transform.position = holdingHand.position;
       
        
        
        //toGrab.transform.SetParent(holdingHand);
        //toGrab.isKinematic = true;



    }

    public void DropObject()
    { 
        if(objectInHold != null)
        {

            objectInHold.useGravity = true;
            objectInHold.drag = 0;
            objectInHold = null;

        }
        
        

        //objectInHold.isKinematic = false;
        // objectInHold.transform.SetParent(null);
    }

    private void Update()
    {
        if (objectInHold != null && Vector3.Distance(holdingHand.position, objectInHold.transform.position) > 0.1f)
        {
            MoveObject();
        }
    }

    public void MoveObject()
    {
        Vector3 targetDirection = holdingHand.position - objectInHold.transform.position;
        objectInHold.AddForce(targetDirection * syncStrength);

    }
}
