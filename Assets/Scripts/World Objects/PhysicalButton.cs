using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class PhysicalButton : MonoBehaviour, IInteractable
{

    public Action OnPressed;
    public void StartInteraction()
    {
        Debug.Log("pressed button");
        OnPressed.Invoke();
    }
    
    public void StopInteraction()
    {
       
    }


}
