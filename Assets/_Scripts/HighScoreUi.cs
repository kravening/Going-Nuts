using TMPro;
using UnityEngine;

public class HighScoreUi : MonoBehaviour
{   
   public delegate void SetHighScore(int score);
   public static event SetHighScore SetHighScoreUiEvent;
   
   [SerializeField] private TextMeshProUGUI textItem;
   [SerializeField] private GameObject highScoreUi;

   private void Start()
   {
      SetHighScoreUiEvent += SetHighScoreUiActive;
      GameTimeManager.GameStartedEvent += SetHighScoreUiNotActive;
   }

   private void OnDestroy()
   {
      SetHighScoreUiEvent -= SetHighScoreUiActive;
      GameTimeManager.GameStartedEvent -= SetHighScoreUiNotActive;
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
