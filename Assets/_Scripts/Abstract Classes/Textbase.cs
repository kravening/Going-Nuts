using TMPro;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;


public  class Textbase : MonoBehaviour
{
   public TextMeshProUGUI textItem;
   
   protected virtual void UpdateText(int text)
   {
      textItem.text = text.ToString();
   }
}