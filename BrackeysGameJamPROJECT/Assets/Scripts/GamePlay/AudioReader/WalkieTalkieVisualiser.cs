using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkieTalkieVisualiser : MonoBehaviour
{
    public AudioSource source;
    public float maxLightness;
    public float minLightness;

    public float loudnessSens = 100f;
    public float threshold = 0.1f;

    public AudioLoudnessDetection detection;

    public Renderer emmisionMaterial;
    public Color emmisionColor;

    public Material instance;

    private void Start()
    {
        instance = emmisionMaterial.sharedMaterials[1];
    }

    private void Update()
    {
        float loudness = detection.GetLoudnessFromAudioClip(source.timeSamples, source.clip) * loudnessSens;

        if (loudness < threshold) 
        {
            loudness = 0;
        }

        Debug.Log(loudness);

        emmisionMaterial.sharedMaterials[1].SetFloat("_Strength", loudness * 10f);
    }
}
