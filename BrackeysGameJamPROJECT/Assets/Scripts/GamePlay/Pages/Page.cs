using UnityEngine;

[CreateAssetMenu(menuName = "Page", fileName = "Blank Page")]
public class Page : ScriptableObject
{
    public string pageTitle;
    public int pageIndex;

    public string pageBody;
}
