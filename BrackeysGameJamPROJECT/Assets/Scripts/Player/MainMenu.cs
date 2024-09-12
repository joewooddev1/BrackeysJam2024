using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LoadGame() 
    {
        SceneManager.LoadScene(0);
    }

    public void LoadLastSave() 
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("CurrentDay"));
    }
}
