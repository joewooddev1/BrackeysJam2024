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

    public string interactionName;
}
