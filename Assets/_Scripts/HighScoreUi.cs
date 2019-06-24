using TMPro;
using UnityEngine;

public class HighScoreUi : MonoBehaviour
{   
   /// <summary>
   /// Variabelen highscore is nodig om het actief en niet actief te zetten
   /// textItem is nodig om de highscore aan het einde van de game te laten zien
   /// </summary>
   [SerializeField] private TextMeshProUGUI textItem;
   [SerializeField] private GameObject highScoreUi;

   /// <summary>
   /// Subcribes SetHighScoreUiActive method op SetHighScoreUiEvent
   /// Subcribes SetHighScoreUiNotactive method op GameStartedEvent
   /// </summary>
   private void Start()
   {
      EventCatalogue.SetHighScoreUiEvent += SetHighScoreUiActive;
      EventCatalogue.GameStartedEvent += SetHighScoreUiNotActive;
   }
/// <summary>
/// Unsubcribes all subscribed events
/// </summary>
   private void OnDestroy()
   {
      EventCatalogue.SetHighScoreUiEvent -= SetHighScoreUiActive;
      EventCatalogue.GameStartedEvent -= SetHighScoreUiNotActive;
   }

   /// <summary>
   /// Set de highScore board active en met de laaste score die is behaald
   /// </summary>
   /// <param name="highscore"></param>
   private void SetHighScoreUiActive(int highscore)
   {
      
      highScoreUi.SetActive(true);
      textItem.text = highscore.ToString();
   }

   /// <summary>
   /// Set het highscore board in actief
   /// </summary>
   private void SetHighScoreUiNotActive()
   {
      highScoreUi.SetActive(false);
   }
}