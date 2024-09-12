using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayLevelNumberSave : MonoBehaviour
{
    public TMP_Text text;

    private void OnEnable()
    {
        text.text = $"load day : {PlayerPrefs.GetInt("CurrentDay") + 1}";
    }
}
