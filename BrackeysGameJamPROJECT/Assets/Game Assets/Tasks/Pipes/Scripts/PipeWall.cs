using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeWall : MonoBehaviour
{
    [SerializeField] private GameObject[] allCrackPoints;

    [SerializeField] private float timeBetweenBreakMax;
    [SerializeField] private float timeBetweenBreakMin;

    [SerializeField] private VavleInteraction valve;

    private float timeSinceLastCrack;
    private float crackTime;

    bool canCrack;

    private void Start()
    {
        InvokeOverTime();

        valve.onInteracted.AddListener(InvokeOverTime);
    }

    public void InvokeOverTime() 
    {
        Invoke("SelectAndCrackRandomPipe", Random.Range(timeBetweenBreakMin, timeBetweenBreakMax));
    }

    public void GenerateCrackTime() 
    {
        crackTime = Random.Range(timeBetweenBreakMin, timeBetweenBreakMax);
    }

    public void SelectAndCrackRandomPipe() 
    {
        int index = Random.Range(0, allCrackPoints.Length - 1);
        allCrackPoints[index].SetActive(true);
        allCrackPoints[index].GetComponent<CrackedPipe>().ReEnable();
        timeSinceLastCrack = 0;
        GenerateCrackTime();
    }
}
