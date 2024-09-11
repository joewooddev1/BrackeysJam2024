using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SlidingDoorSpawner : MonoBehaviour
{
    [SerializeField] private GameObject food;
    [SerializeField] private GameObject key;
    [SerializeField] private GameObject battery;

    [SerializeField] UnityEvent onSpawn;

    [SerializeField] private Transform spawnPoint;
    public void SpawnSelectedItem(string name) 
    {
        if (name == "food") { Instantiate(food, spawnPoint.position, spawnPoint.rotation); }
        if (name == "key") { GameObject keySpawned = Instantiate(key, spawnPoint.position, spawnPoint.rotation); keySpawned.GetComponent<DoorKey>().DoorMatchLookup("JanitorDoor"); }
        if (name == "battery") { Instantiate(battery, spawnPoint.position, spawnPoint.rotation); }

        onSpawn.Invoke();
    }
}
