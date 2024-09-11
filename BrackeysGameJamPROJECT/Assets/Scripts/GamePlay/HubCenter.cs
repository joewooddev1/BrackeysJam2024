using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class Task 
{
    public GameObject text;
    public GameObject light;
    public bool completed;
}

public class HubCenter : MonoBehaviour
{
    [SerializeField] private Task[] tasks;

    [SerializeField] private Material completed;
    [SerializeField] private Material inCompleted;

    public static HubCenter Instance { get; private set; }

    [SerializeField] private AudioClip beepNoise;
    [SerializeField] private AudioSource beepSource;

    [SerializeField] private float timeBetweenBeeps;

    private void Start()
    {
        
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

        StartCoroutine(BeepNoise());
    }
    public void TriggerTask(int taskIndex) 
    {
        tasks[taskIndex].completed = !tasks[taskIndex].completed;
        if (!tasks[taskIndex].completed) { tasks[taskIndex].light.GetComponent<Renderer>().sharedMaterial = inCompleted; } else { tasks[taskIndex].light.GetComponent<Renderer>().sharedMaterial = completed; }
    }

    IEnumerator BeepNoise() 
    {
        for (int i = 0; i < tasks.Length; i++)
        {
            if (tasks[i].completed) { yield return null; }
        }
        
        beepSource.PlayOneShot(beepNoise);
        yield return new WaitForSeconds(timeBetweenBeeps);
        StartCoroutine(BeepNoise());
    }
}
