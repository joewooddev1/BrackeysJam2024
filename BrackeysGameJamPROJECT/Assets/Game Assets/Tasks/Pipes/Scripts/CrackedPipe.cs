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

    [SerializeField] private bool gasLeaking;

    int playerDamage;
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

        StartCoroutine(HarmPlayer());

        playerDamage = 1;
    }

    public IEnumerator HarmPlayer() 
    {
        CharacterState.Instance.PlayerTakeDamage(playerDamage, "gas");
        yield return new WaitForSeconds(5f);
        StartCoroutine(HarmPlayer());
    }

    public void CloseLeak() 
    {
        StartCoroutine(CloseLeakSequence());

        HubCenter.Instance.TriggerTask(2);
    }

    public IEnumerator CloseLeakSequence() 
    {
        yield return new WaitForSeconds(1f);
        mainSteamParticle.emissionRate = 0;
        secondarySmoke.emissionRate = 0;
        mainSteamSound.volume = 0;
        pipeCrack.SetActive(false);

        playerDamage = 0;
    }
}
