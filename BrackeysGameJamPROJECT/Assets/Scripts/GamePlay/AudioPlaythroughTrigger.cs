using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AudioPlaythroughTrigger : MonoBehaviour
{
    public UnityEvent onTriggered;

    [SerializeField] int day;
    [SerializeField] int voicelineIndex;
    [SerializeField] private bool doAudio = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            onTriggered.Invoke();

            if (doAudio) { GameStateManager.Instance.TriggeredVoiceLine(voicelineIndex, day); }
        }
    }
}
