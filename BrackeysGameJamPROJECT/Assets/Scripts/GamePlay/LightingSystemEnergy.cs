using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingSystemEnergy : MonoBehaviour
{
    private Light light;
    private float startIntensity;

    private void Start()
    {
        TryGetComponent(out light);
        startIntensity = light.intensity;
    }

    private void Update()
    {
        if (GameStateManager.Instance.energyLevel > 0) 
        {
            light.intensity = startIntensity * ((GameStateManager.Instance.energyLevel) / 100f);
        }

        if ((GameStateManager.Instance.energyLevel) < 5f && GameStateManager.Instance.energyLevel > 0)
        {
            // start flicker sequence

            StartCoroutine(FlickerSequence());
        }
        else if (GameStateManager.Instance.energyLevel <= 0)
        {
            light.intensity = 0;
        }
    }

    IEnumerator FlickerSequence() 
    {
        light.intensity = 0;
        yield return new WaitForSeconds(Random.Range(0.3f, 0.9f));
        light.intensity = startIntensity;
    }
}
