using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrackedPipe : MonoBehaviour
{
    [SerializeField] VavleInteraction valveControl;
    [SerializeField] ParticleSystem mainSteamParticle;
    [SerializeField] ParticleSystem secondarySmoke;
    [SerializeField] GameObject pipeCrack;
    [SerializeField] AudioSource mainSteamSound;

    private void Start()
    {
        valveControl.onInteracted.AddListener(CloseLeak);
    }

    public void ReEnable() 
    {
        mainSteamParticle.emissionRate = 281.48f;
        secondarySmoke.emissionRate = 10f;
        mainSteamSound.volume = .25f;
        pipeCrack.SetActive(true);
    }

    public void CloseLeak() 
    {
        StartCoroutine(CloseLeakSequence());
    }

    public IEnumerator CloseLeakSequence() 
    {
        yield return new WaitForSeconds(1f);
        mainSteamParticle.emissionRate = 0;
        secondarySmoke.emissionRate = 0;
        mainSteamSound.volume = 0;
        pipeCrack.SetActive(false);
    }
}
