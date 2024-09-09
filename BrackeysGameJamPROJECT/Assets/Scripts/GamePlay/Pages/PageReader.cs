using TMPro;
using UnityEngine;

public class PageReader : MonoBehaviour
{
    public TMP_Text title;
    public TMP_Text body;

    public GameObject reader;
    bool reading;

    public void ReadPage(Page page) 
    {
        reader.SetActive(true);

        title.text = page.pageTitle;
        body.text = page.pageBody;

        reading = true;
    }

    public void ClosePage() 
    {
        reader.SetActive(false);
    }

    public void Update()
    {
        if(reading) { if(Input.GetKeyDown(KeyCode.Space)) { ClosePage(); reading = false; } }
    }
}
