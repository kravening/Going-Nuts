using TMPro;
using UnityEngine;

/// <summary>
/// a base cass for ui elements that gets it's text updated
/// </summary>
public class Textbase : MonoBehaviour
{
    /// <summary>
    ///  holds a text ui component
    /// </summary>
    public TextMeshProUGUI textItem;

    /// <summary>
    /// updates the on the textItem ui component
    /// </summary>
    /// <param name="text"></param>
    protected virtual void UpdateText(int text)
    {
        textItem.text = text.ToString();
    }
}