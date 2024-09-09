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
    [SerializeField] private int amountOfTurns;

    bool isTurning;
    int turnedAmount;

    float currentAngle;

    public void Update()
    {
        if (isTurning)
        {
            transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + currentAngle), 5 * Time.deltaTime);
        }
    }

    public void InvokeInteractionEvent() 
    {
        if (!isTurning)
        {
            StartCoroutine(TurnValve());
        }
    }

    IEnumerator TurnValve() 
    {
        currentAngle += 45f;
        isTurning = true;
        source.PlayOneShot(squeakyValve, Random.Range(0.1f, 0.15f));
        source.pitch = Random.Range(.9F, 1.15F);
        yield return new WaitForSeconds(Random.Range(0.5f, 1f));

        turnedAmount++;

        currentAngle = 0;

        if (turnedAmount == amountOfTurns) 
        {
            onInteracted.Invoke();

            turnedAmount = 0;
        }

        isTurning = false;
    }
}
