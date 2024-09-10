using System.Collections;
using UnityEngine;

public enum GameState 
{
    Intro,
    Sleeping,
    Day1,
    Day2,
    Day3,
    Day4,
    Day5,
    Day6,
    Day7,
}

[System.Serializable]
public class DayDependantVoiceLines 
{
    public GameState state;
    public AudioClip[] voiceLines;
}

public class GameStateManager : MonoBehaviour
{
    public GameState currentGameState;

    public PlayerCharacterController characterController;
    public FootstepSounds footstepSounds;

    [SerializeField] DayDependantVoiceLines[] voiceLines;

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
        if(currentGameState == GameState.Day1) 
        {
            // disable certain interactions

            // intro voiceline
            WalkieTalkieVoicelineSystem.Instance.SwitchAudioVoiceLine(voiceLines[0].voiceLines[0]);
        }

        if (currentGameState == GameState.Sleeping) 
        {
            CharacterState.Instance.DisableCharacter();
        }
    }

    // day 1 state management
    public void TriggeredVoiceLine(int voicelineNumber, int day) 
    {
        WalkieTalkieVoicelineSystem.Instance.SwitchAudioVoiceLine(voiceLines[day].voiceLines[voicelineNumber]);
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
