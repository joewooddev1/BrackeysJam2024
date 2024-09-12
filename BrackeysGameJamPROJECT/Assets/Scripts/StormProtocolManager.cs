using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StormProtocolManager : MonoBehaviour
{
    [SerializeField] private StormRoomGame[] buttons;

    [SerializeField] UnityEvent onCompleted;

    public bool completed;
    public bool allLevelsDone;

    public void CheckComplete()
    { 
        for (int i = 0; i < buttons.Length; i++)
        {
            allLevelsDone = buttons[i].matches;
        }
    }

    private void Update()
    {
        if (allLevelsDone)
        {
            if (!completed) { onCompleted.Invoke(); completed = true; HubCenter.Instance.TriggerTask(4); }
        }
    }
}
