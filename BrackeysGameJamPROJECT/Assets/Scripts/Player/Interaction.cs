using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public enum InteractionType 
{
    click,
    hold
}

public class Interaction : MonoBehaviour
{
    public UnityEvent onInteracted;
    public UnityEvent onDropped;
    public InteractionType type;
    public bool canGrab = true;

    public string interactionName;

    private void Start()
    {
        canGrab = true;
    }

    public void GraceGrab() 
    {
        StartCoroutine(GraceGrabAwait());
    }

    public IEnumerator GraceGrabAwait() 
    {
        canGrab = false;
        yield return new WaitForSeconds(1f);
        canGrab = true;
    }
}
