using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StormProtocolManager : MonoBehaviour
{
    [SerializeField] private StormRoomGame[] buttons;

    [SerializeField] UnityEvent onCompleted;

    public bool completed;
    public bool allLevelsDone = false;

    public void CheckComplete()
    {
        if (buttons[0].matches && buttons[1].matches && buttons[2].matches && buttons[3].matches && buttons[4].matches && buttons[5].matches) 
        {
            allLevelsDone = true;
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
