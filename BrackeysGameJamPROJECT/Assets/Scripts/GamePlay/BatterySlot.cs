using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BatterySlot : MonoBehaviour
{
    [SerializeField] private Transform batterySlot;
    [SerializeField] UnityEvent onInsert;

    bool full;

    Transform currentBattery;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody.GetComponent<Battery>() != null && !full) 
        {
            onInsert.Invoke();

            other.transform.position = batterySlot.position;
            other.transform.rotation = batterySlot.rotation;

            Interactor.Instance.isHolding = false;

            full = true;

            currentBattery = other.transform;

            other.attachedRigidbody.GetComponent<Interaction>().GraceGrab();
            other.attachedRigidbody.isKinematic = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.attachedRigidbody.GetComponent<Battery>() != null && full)
        {
            other.attachedRigidbody.isKinematic = false;

            full = false;
        }
    }
}
