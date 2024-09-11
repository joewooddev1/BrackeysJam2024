using UnityEngine;
using UnityEngine.Events;

public class FuelGauge : MonoBehaviour
{
    public static FuelGauge Instance { get; private set; }

    [SerializeField] private float maxFuel;
    [SerializeField] private float minFuel;
    [Range(0, 100)] public float currentFuel;

    public Transform fullRotation;
    public Transform emptyRotation;

    [SerializeField] private Transform needle;

    [SerializeField] private UnityEvent onFull;

    bool invoked;


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

    private void Update()
    {
        needle.rotation = Quaternion.Lerp(emptyRotation.rotation, fullRotation.rotation, currentFuel / (maxFuel - minFuel));
    }

    public void AddFuel(int multiplier) 
    {
        currentFuel += multiplier;

        if (currentFuel >= maxFuel) 
        {
            if (!invoked) { onFull.Invoke(); invoked = true; }

            Debug.Log("full");
            
            if (GameStateManager.Instance.currentGameState == GameState.Day1) 
            {
                GameStateManager.Instance.DayOneFinishTasks();
            }
            else if (GameStateManager.Instance.currentGameState == GameState.Day2)
            {
                GameStateManager.Instance.DayOneFinishTasks();
            }
            else if (GameStateManager.Instance.currentGameState == GameState.Day3)
            {
                //GameStateManager.Instance.DayOneFinishTasks();
            }
            else if (GameStateManager.Instance.currentGameState == GameState.Day4)
            {
                //GameStateManager.Instance.DayOneFinishTasks();
            }
            else if (GameStateManager.Instance.currentGameState == GameState.Day5)
            {
                //GameStateManager.Instance.DayOneFinishTasks();
            }
            else if (GameStateManager.Instance.currentGameState == GameState.Day6)
            {
                //GameStateManager.Instance.DayOneFinishTasks();
            }
            else if (GameStateManager.Instance.currentGameState == GameState.Day7)
            {
                //GameStateManager.Instance.DayOneFinishTasks();
            }
        }
    }
}
