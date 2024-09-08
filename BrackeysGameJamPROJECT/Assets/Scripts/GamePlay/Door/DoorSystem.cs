using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSystem : MonoBehaviour
{
    public bool locked;
    public Rigidbody doorRigidbody;

    public Interaction handleInteraction;

    public Transform keyHole;
    public AudioSource keySound;

    private void Update()
    {
        if (locked)
        {
            doorRigidbody.isKinematic = true;

            handleInteraction.interactionName = "Door (LOCKED)";
        }
        else 
        {
            doorRigidbody.isKinematic = false;

            handleInteraction.interactionName = "Door (UNLOCKED)";
        }
    }

    public void UnlockDoor() 
    {
        locked = false;

        keySound.Play();
    }
}
