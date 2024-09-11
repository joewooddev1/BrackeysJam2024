using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class TimedEvent : MonoBehaviour
{
    [SerializeField] private float timeTillEvent;

    [SerializeField] private UnityEvent triggerEvent;

    public void TriggerWaitedEvent() 
    {
        StartCoroutine(TimedEventWait());
    }

    IEnumerator TimedEventWait() 
    {
        yield return new WaitForSeconds(timeTillEvent);
        triggerEvent.Invoke();
    }
}
