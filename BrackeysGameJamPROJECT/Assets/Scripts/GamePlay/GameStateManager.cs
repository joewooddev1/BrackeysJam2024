using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

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
    public GameObject triggers;
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

    [Header("Day Specific Events")]
    [SerializeField] private Transform foodSpawnPointDayOne;
    [SerializeField] private GameObject foodSpawnPrefab;

    [Header("INSANE AMOUNT OF EVENTS")]
    [SerializeField] private UnityEvent finishDayOneEvent;
    [SerializeField] private UnityEvent finishDayTwoEvent;
    [SerializeField] private UnityEvent finishDayThreeEvent;
    [SerializeField] private UnityEvent finishDayFourEvent;
    [SerializeField] private UnityEvent finishDayFiveEvent;
    [SerializeField] private UnityEvent finishDaySixEvent;
    [SerializeField] private UnityEvent finishDaySevenEvent;

    public float energyLevel;

    bool dayOneCompleted;

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

    private void Start()
    {
        StartCoroutine(DepleatEnergy());
    }

    public IEnumerator DepleatEnergy()
    {
        energyLevel -= 1f;
        yield return new WaitForSeconds(5f);
        StartCoroutine(DepleatEnergy());
    }

    private void Update()
    {
        if(currentGameState == GameState.Day1) 
        {
            // disable certain interactions

            // intro voiceline
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

    public void AdvanceDay() 
    {
        day += 1;

        SceneManager.LoadScene(day);

        energyLevel = 100;

        voiceLines[day].triggers.SetActive(true);
    }

    public void DayOneFinishTasks() 
    {
        if (!dayOneCompleted)
        {
            WalkieTalkieVoicelineSystem.Instance.SwitchAudioVoiceLine(voiceLines[0].voiceLines[3]);

            dayOneCompleted = true;

            finishDayOneEvent.Invoke();
            voiceLines[0].triggers.SetActive(false);

        }
    }
                                                                            
    public void DayTwoFinishTasks()
    {
        if (!dayOneCompleted)
        {
            WalkieTalkieVoicelineSystem.Instance.SwitchAudioVoiceLine(voiceLines[0].voiceLines[3]);

            dayOneCompleted = true;

            finishDayTwoEvent.Invoke();
            voiceLines[1].triggers.SetActive(false);

        }
    }

    public void DayThreeFinishTasks()
    {

    }

    public void DayFourFinishTasks()
    {

    }

    public void DayFiveFinishTasks()
    {

    }

    public void DaySixFinishTasks()
    {

    }

    public void DaySevenFinishTasks()
    {
        // final day
    }
}
