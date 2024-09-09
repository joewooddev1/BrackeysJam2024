using System.Collections;
using UnityEngine;

public enum GameState 
{
    Intro,
    Sleeping,
    Exploration,
    Mission,
    FinalShowdown
}

public class GameStateManager : MonoBehaviour
{
    public GameState currentGameState;

    public PlayerCharacterController characterController;
    public FootstepSounds footstepSounds;

    public static GameStateManager Instance { get; private set; }

    public float hourOfDay;
    public int day;

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

        StartCoroutine(ClockTimer());
    }

    private void Update()
    {
        if(currentGameState == GameState.Intro) 
        {
            // intro code bla bla bla
        }

        if (currentGameState == GameState.Sleeping) 
        {
            characterController.enabled = false;
            footstepSounds.enabled = false;
        }

        if(currentGameState == GameState.Exploration) 
        {
            characterController.enabled = true;
            footstepSounds.enabled = true;
        }
    }

    IEnumerator ClockTimer() 
    {
        yield return new WaitForSecondsRealtime(60f);


        if (hourOfDay == 24)
        {
            day++;
        }

        if (hourOfDay < 24) 
        {
            hourOfDay += 1;
        }

        StartCoroutine(ClockTimer());
    }
}
