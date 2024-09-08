using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrackedPipe : MonoBehaviour
{
    [SerializeField] VavleInteraction valveControl;

    private void Start()
    {
        valveControl.onInteracted.AddListener(CloseLeak);
    }

    public void CloseLeak() 
    {
        StartCoroutine(CloseLeakSequence());
    }

    public IEnumerator CloseLeakSequence() 
    {
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }
}
