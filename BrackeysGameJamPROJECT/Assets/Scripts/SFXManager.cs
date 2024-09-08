using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public bool tension;

    public AudioSource drumsSource;

    private void Update()
    {
        if (tension)
        {
            drumsSource.volume = .15f;
        }
        else 
        {
            drumsSource.volume = 0;
        }
    }
}
