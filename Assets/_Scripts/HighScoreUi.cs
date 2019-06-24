using TMPro;
using UnityEngine;

public class HighScoreUi : MonoBehaviour
{   
   [SerializeField] private TextMeshProUGUI textItem;
   [SerializeField] private GameObject highScoreUi;

   private void Start()
   {
      EventCatalogue.SetHighScoreUiEvent += SetHighScoreUiActive;
      EventCatalogue.GameStartedEvent += SetHighScoreUiNotActive;
   }

   private void OnDestroy()
   {
      EventCatalogue.SetHighScoreUiEvent -= SetHighScoreUiActive;
      EventCatalogue.GameStartedEvent -= SetHighScoreUiNotActive;
   }

   private void SetHighScoreUiActive(int highscore)
   {
      
      highScoreUi.SetActive(true);
      textItem.text = highscore.ToString();
   }

   private void SetHighScoreUiNotActive()
   {
      highScoreUi.SetActive(false);
   }
}