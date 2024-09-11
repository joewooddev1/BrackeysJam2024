using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashShoot : MonoBehaviour
{
    [SerializeField] private int minAmountOfWood;
    [SerializeField] private int maxAmountOfWood;

    [SerializeField] private int minAmountOfPaper;
    [SerializeField] private int maxAmountOfPaper;

    [SerializeField] private GameObject woodChunkPrefab;
    [SerializeField] private GameObject paperScrapPrefab;
    [SerializeField] private GameObject[] randomJunk;

    [SerializeField] private float shootSizeX;
    [SerializeField] private float shootSizeZ;

    public bool scrapSpawned;

    public void SpawnJunk() 
    {
        if (scrapSpawned) return;
        
        int randomWoodAmount = Random.Range(minAmountOfWood, maxAmountOfWood);
        int randomPaperAmount = Random.Range(minAmountOfPaper, maxAmountOfPaper);
        int randomOther = Random.Range(3, 9);
        
        for (int i = 0; i < randomPaperAmount; i++)
        {
            Instantiate(paperScrapPrefab, transform.position + new Vector3(Random.Range(-shootSizeX, shootSizeX), 0, Random.Range(-shootSizeZ, shootSizeZ)), Quaternion.identity);
        }

        for (int i = 0; i < randomWoodAmount; i++)
        {
            Instantiate(woodChunkPrefab, transform.position + new Vector3(Random.Range(-shootSizeX, shootSizeX), 0, Random.Range(-shootSizeZ, shootSizeZ)), Quaternion.identity);
        }

        for (int i = 0; i < randomOther; i++)
        {
            Instantiate(randomJunk[Random.Range(0, randomJunk.Length - 1)], transform.position + new Vector3(Random.Range(-shootSizeX, shootSizeX), 0, Random.Range(-shootSizeZ, shootSizeZ)), Quaternion.identity);
        }

        scrapSpawned = true;
    }
}
