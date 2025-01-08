using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PressurePlate : MonoBehaviour
{
    [SerializeField] private Rigidbody correctRigidbody;
    public UnityEvent OnPressureStart;
    public UnityEvent OnPressureExit;
    private void OnTriggerEnter(Collider other)
    {
        if (correctRigidbody == other.attachedRigidbody)
        { OnPressureStart.Invoke(); }
    }

    private void OnTriggerExit(Collider other)
    {
        if (correctRigidbody == other.attachedRigidbody)
        { OnPressureExit.Invoke(); }
    }
}
