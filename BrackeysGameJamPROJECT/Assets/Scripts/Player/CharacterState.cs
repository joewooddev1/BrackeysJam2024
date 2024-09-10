using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterState : MonoBehaviour
{
    public static CharacterState Instance { get; private set; }

    [SerializeField] private Behaviour[] toDisable;

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void DisableCharacter() 
    {
        for (int i = 0; i < toDisable.Length; i++)
        {
            toDisable[i].enabled = false;
        }
    }

    public void EnableCharacter()
    {
        for (int i = 0; i < toDisable.Length; i++)
        {
            toDisable[i].enabled = true;
        }
    }


    public void KillPlayer()
    {
        SceneManager.LoadScene(0);
    }
}
