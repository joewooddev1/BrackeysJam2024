using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorKey : MonoBehaviour
{
    public DoorSystem doorMatch;
    public void DoorMatchLookup(string doorNameMatch) 
    {
        doorMatch = GameObject.Find(doorNameMatch).GetComponent<DoorSystem>();
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, doorMatch.keyHole.position) < 1f) 
        {
            doorMatch.UnlockDoor();

            Destroy(gameObject);
            Interactor.Instance.isHolding = false;
        }
    }
}
