using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlashRed : MonoBehaviour
{
    public float interval = 1;
    public float audioInterval = 1;

    Light light;
    public float lightIntesity;
    float startIntensity;
    private AudioSource source;
    private void Start()
    {
        TryGetComponent(out light);
        TryGetComponent(out source);
    }

    float timer;
    float audioTimer;

    void Update()
    {
        timer += Time.deltaTime;
        audioTimer += Time.deltaTime;
        
        if (timer > interval)
        {            
            light.enabled = !light.enabled;
            timer -= interval;
        }

        if (audioTimer > audioInterval)
        {
            if (source) { source.Play(); }
            audioTimer -= audioInterval;
        }
    }
}
