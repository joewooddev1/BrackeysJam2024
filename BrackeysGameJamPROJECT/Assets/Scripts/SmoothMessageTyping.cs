using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class SmoothMessageTyping : MonoBehaviour
{
    [SerializeField] private AudioClip keyboardType;
    [SerializeField] private string totalMessage;
    [SerializeField] private TMP_Text messageSlot;
    [SerializeField] private UnityEvent onTypingCompleted;
    [SerializeField] private float timeBetweenLetters = 0.05f;
    private void Start()
    {
        StartCoroutine(WriteMessage());
    }

    IEnumerator WriteMessage() 
    {
        messageSlot.text = string.Empty;
        
        for (int i = 0; i < totalMessage.Length; i++)
        {
            messageSlot.text += totalMessage[i];

            yield return new WaitForSeconds(timeBetweenLetters);

            if (i == totalMessage.Length - 1) { onTypingCompleted.Invoke(); }
        }

        yield return null;
    }
}
