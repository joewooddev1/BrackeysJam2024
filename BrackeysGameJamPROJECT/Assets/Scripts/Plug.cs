using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Plug : MonoBehaviour
{
    public bool inserted;

    public UnityEvent onInserted;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Socket>()) 
        {
            transform.position = other.transform.position;
            transform.rotation = other.transform.rotation;

            onInserted.Invoke();
        }
    }
}
