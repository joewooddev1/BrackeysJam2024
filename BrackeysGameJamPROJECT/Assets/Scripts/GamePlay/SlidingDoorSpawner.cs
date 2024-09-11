using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingDoorSpawner : MonoBehaviour
{
    [SerializeField] private GameObject food;
    [SerializeField] private GameObject key;
    [SerializeField] private GameObject battery;

    [SerializeField] private Transform spawnPoint;
    public void SpawnSelectedItem(string name) 
    {
        if (name == "food") { Instantiate(food, spawnPoint.position, spawnPoint.rotation); }
        if (name == "key") { Instantiate(key, spawnPoint.position, spawnPoint.rotation); }
        if (name == "battery") { Instantiate(battery, spawnPoint.position, spawnPoint.rotation); }
    }
}
