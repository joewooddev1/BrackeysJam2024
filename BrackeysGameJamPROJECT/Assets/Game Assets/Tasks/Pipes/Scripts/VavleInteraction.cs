using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VavleInteraction : MonoBehaviour
{
    [Header("Outward Events")]
    public UnityEvent onInteracted;

    [Header("Interaction Audio")]
    [SerializeField] private AudioClip squeakyValve;
    [SerializeField] private AudioSource source;

    bool isTurning;

    public void InvokeInteractionEvent() 
    {
        if (!isTurning)
        {
            StartCoroutine(SoundValve());

            onInteracted.Invoke();
        }
    }

    IEnumerator SoundValve() 
    {
        isTurning = true;
        source.PlayOneShot(squeakyValve, Random.Range(0.1f, 0.15f));
        source.pitch = Random.Range(.9F, 1.15F);
        yield return new WaitForSeconds(Random.Range(0.5f, 1f));
        source.PlayOneShot(squeakyValve, Random.Range(0.1f, 0.15f));
        source.pitch = Random.Range(.9F, 1.15F);
        yield return new WaitForSeconds(Random.Range(0.5f, 1f));
        source.PlayOneShot(squeakyValve, Random.Range(0.1f, 0.15f));
        source.pitch = Random.Range(.9F, 1.15F);
        yield return new WaitForSeconds(Random.Range(0.5f, 1f));

        isTurning = false;
    }
}
