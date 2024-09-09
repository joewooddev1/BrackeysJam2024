using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageInteraction : MonoBehaviour
{
    [SerializeField] private PageReader pageReader;
    [SerializeField] private Page pageContents;

    public void OpenAndReadPage() 
    {
        pageReader.ReadPage(pageContents);
    }
}
