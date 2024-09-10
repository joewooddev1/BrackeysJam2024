using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SleepSystem : MonoBehaviour
{

    [SerializeField] private Color sleepingColor;
    [SerializeField] private Color awakeColor;

    [SerializeField] private Image fadeToBlack;

    [SerializeField] private bool sleeping;

    private void Update()
    {
        if (sleeping)
        {
            fadeToBlack.color = Color.Lerp(fadeToBlack.color, sleepingColor, 5 * Time.deltaTime);

            GameStateManager.Instance.currentGameState = GameState.Sleeping;
        }
        else 
        {
            fadeToBlack.color = Color.Lerp(fadeToBlack.color, awakeColor, 5 * Time.deltaTime);
        }
    }

    public void SleepCycle() 
    {
        StartCoroutine(Sleep());
    }

    public void FadeImage() 
    {
        sleeping = ! sleeping;
    }

    IEnumerator Sleep() 
    {
        FadeImage();
        yield return new WaitForSeconds(5f);
        FadeImage();
    }
}
