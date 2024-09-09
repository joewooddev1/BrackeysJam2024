using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OcclusionDetection : MonoBehaviour
{
    [SerializeField] private Transform player;

    [SerializeField] private AudioSource source;
    [SerializeField] private AudioMixerGroup mixer;

    public bool occluded;
    private void Update()
    {
        if (Physics.Linecast(transform.position, player.position))
        {
            occluded = true;
        }
        else 
        {
            occluded = false;
        }

        if (occluded)
        {
            source.spatialBlend = 0;
            source.spatialize = false;
            source.outputAudioMixerGroup = null;
        }
        else 
        {
            source.spatialBlend = 1;
            source.spatialize = true;
            source.outputAudioMixerGroup = mixer;
        }
    }
}
