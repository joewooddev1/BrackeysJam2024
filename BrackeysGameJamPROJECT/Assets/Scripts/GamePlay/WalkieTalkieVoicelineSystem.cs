using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkieTalkieVoicelineSystem : MonoBehaviour
{
    [SerializeField] private AudioSource source;

    public static WalkieTalkieVoicelineSystem Instance { get; private set; }

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void SwitchAudioVoiceLine(AudioClip clip) 
    {
        source.clip = null;
        source.PlayOneShot(clip);
    }
}
