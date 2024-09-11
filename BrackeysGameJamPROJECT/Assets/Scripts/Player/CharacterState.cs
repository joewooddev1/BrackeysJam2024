using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterState : MonoBehaviour
{
    public static CharacterState Instance { get; private set; }

    [SerializeField] private Behaviour[] toDisable;

    [SerializeField] private AudioClip coughing;

    public float playerHealth;

    private AudioSource source;

    private void Start()
    {
        TryGetComponent(out source);
    }

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

    public void PlayerTakeDamage(int amount, string damageType) 
    {
        // do damage notification
        playerHealth -= amount;

        if (damageType == "gas" && amount > 0) 
        {
            source.pitch = Random.Range(1f, 1.15f);
            source.PlayOneShot(coughing, 0.15f);
        }
    }

    private void Update()
    {
        if (playerHealth <= 0) 
        {
            KillPlayer();
        }
    }


    public void KillPlayer()
    {
        SceneManager.LoadScene(1);
    }
}
