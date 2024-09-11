using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Incinrator : MonoBehaviour
{
    [SerializeField] private HingeJoint doorJoint;
    [SerializeField] private List<GameObject> itemsInIncinirator;
    bool firstTime;

    private void OnTriggerEnter(Collider other)
    {
        itemsInIncinirator.Add(other.gameObject);
    }

    private void Update()
    {
        if (doorJoint.angle < 5f) 
        {
            // door closed
            if (itemsInIncinirator.Count > 0) 
            {
                for (int i = 0; i < itemsInIncinirator.Count; i++)
                {
                    FuelGauge.Instance.AddFuel(25);
                    Destroy(itemsInIncinirator[i]);
                }
            }
        }
    }
}
