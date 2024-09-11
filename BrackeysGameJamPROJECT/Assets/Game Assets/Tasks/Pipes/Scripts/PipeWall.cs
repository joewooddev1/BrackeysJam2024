using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PipeWall : MonoBehaviour
{
    [SerializeField] private GameObject[] allCrackPoints;

    [SerializeField] private float timeBetweenBreakMax;
    [SerializeField] private float timeBetweenBreakMin;

    [SerializeField] private VavleInteraction valve;

    private float timeSinceLastCrack;
    private float crackTime;

    public int amountOfPops;

    bool canCrack;

    public UnityEvent onFirstPop;

    public static PipeWall Instance { get; private set; }

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

    public void GenerateCrackTime() 
    {
        crackTime = Random.Range(timeBetweenBreakMin, timeBetweenBreakMax);
        Invoke("SelectAndCrackRandomPipe", crackTime);
    }

    public void SelectAndCrackRandomPipe() 
    {
        HubCenter.Instance.TriggerTask(2);

        int index = Random.Range(0, allCrackPoints.Length - 1);
        allCrackPoints[index].SetActive(true);
        allCrackPoints[index].GetComponent<CrackedPipe>().ReEnable();
        timeSinceLastCrack = 0;
        GenerateCrackTime();

        if (amountOfPops < 1)
        {
            // play oh i forgot blalala
            GameStateManager.Instance.TriggeredVoiceLine(2, 0);
            onFirstPop.Invoke();
        }

        amountOfPops++;
    }
}
