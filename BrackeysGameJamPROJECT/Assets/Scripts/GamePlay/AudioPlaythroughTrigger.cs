using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AudioPlaythroughTrigger : MonoBehaviour
{
    public UnityEvent onTriggered;

    [SerializeField] int day;
    [SerializeField] int voicelineIndex;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            onTriggered.Invoke();

            GameStateManager.Instance.TriggeredVoiceLine(voicelineIndex, day);
        }
    }
}
