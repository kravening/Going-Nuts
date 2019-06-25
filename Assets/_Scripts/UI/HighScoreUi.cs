using TMPro;
using UnityEngine;

/// <summary>
/// handles highscore board.
/// </summary>
public class HighScoreUi : MonoBehaviour
{
    /// <summary>
    /// references the text that needs to be updated.
    /// </summary>
    [SerializeField] private TextMeshProUGUI textItem;
    [SerializeField] private GameObject highScoreUi;

    /// <summary>
    /// Subcribes SetHighScoreUiActive method to SetHighScoreUiEvent
    /// Subcribes SetHighScoreUiNotactive method to GameStartedEvent
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
    /// Set highScore board active and updates score to latest score.
    /// </summary>
    /// <param name="highscore"></param>
    private void SetHighScoreUiActive(int highscore)
    {

        highScoreUi.SetActive(true);
        textItem.text = highscore.ToString();
    }

    /// <summary>
    /// Set the highscore board inactive
    /// </summary>
    private void SetHighScoreUiNotActive()
    {
        highScoreUi.SetActive(false);
    }
}