using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeOfItem
{
    Switch,
    Bulb
}

public class StormRoomGame : MonoBehaviour
{
    [SerializeField] TypeOfItem type;

    [SerializeField] StormRoomGame matchingBulb;

    [SerializeField] private Material offMaterial;
    [SerializeField] private Material onMaterial;

    [SerializeField] private string code;

    public bool matches;
    public bool on;

    public Renderer thisRenderer;
    public Renderer bulbRenderer;

    private void Start()
    {
        code = gameObject.name;
        
        float randomOffOrOn = Random.Range(0, 10);

        if (type == TypeOfItem.Bulb)
        {
            if (randomOffOrOn > 5)
            {
                gameObject.GetComponent<Renderer>().sharedMaterial = onMaterial;
                on = true;
            }
            else
            {
                gameObject.GetComponent<Renderer>().sharedMaterial = offMaterial;
                on = false;
            }
        }
        else 
        {
            bulbRenderer = matchingBulb.gameObject.GetComponent<Renderer>();
            thisRenderer = GetComponent<Renderer>();
        }
    }

    private void Update()
    {
        if (type == TypeOfItem.Switch)
        {
            if (thisRenderer.sharedMaterial == bulbRenderer.sharedMaterial)
            {
                matches = true;
            }
        }
    }

    public void ChangeMaterial() 
    {
        if (thisRenderer.sharedMaterial == onMaterial)
        {
            thisRenderer.sharedMaterial = offMaterial;
        }
        else 
        {
            thisRenderer.sharedMaterial = onMaterial;
            matches = true;
        }
    }
}
