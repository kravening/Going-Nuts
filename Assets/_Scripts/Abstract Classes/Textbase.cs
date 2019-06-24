using TMPro;
using UnityEngine;

public  class Textbase : MonoBehaviour
{
   /// <summary>
   /// Text item binnen de game die word verandered
   /// </summary>
   public TextMeshProUGUI textItem;
   
   /// <summary>
   /// Updates the text that handels all the text elementen binnen de game
   /// </summary>
   /// <param name="text"></param>
   protected virtual void UpdateText(int text)
   {
      textItem.text = text.ToString();
   }
}