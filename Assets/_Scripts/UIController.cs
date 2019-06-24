using TMPro;
using UnityEngine;

/// <summary>
/// This controller handles all the UI elements of the game
/// </summary>

//TODO: deze class moet even abstracter gemaakt worden.

public class UIController : SingletonBase<UIController>
{
    /// <summary>
    /// Gets the TextMeshProGui from the scene.
    /// </summary>
    [SerializeField] private TextMeshProUGUI[] textItems;
    [SerializeField] private GameObject highScoreUi;
    private int scoreText;


    /// <summary>
    /// Subscribe
    /// </summary>
    private void Start()
    {
        EventCatalogue.GameEndedEvent += HighScore;
        EventCatalogue.GameStartedEvent += DisableHighScoreUI;
    }
    /// <summary>
    /// unsubscribes
    /// </summary>
    private void OnDestroy()
    {
        EventCatalogue.GameEndedEvent -= HighScore;
        EventCatalogue.GameStartedEvent -= DisableHighScoreUI;
    }

    /// <summary>
    /// Updates the score UI inside the game
    /// </summary>
    /// <param name="score"></param>
    public void UpdateScoreUi(int score)
    {
        scoreText = score;
        textItems[0].text = score.ToString();
    }
    /// <summary>
    /// disables highscore ui
    /// </summary>
    private void DisableHighScoreUI()
    {
        highScoreUi.SetActive(false);
    }

    /// <summary>
    /// enables highscore ui
    /// </summary>
	private void HighScore()
    {
        highScoreUi.SetActive(true);
        textItems[2].text = scoreText.ToString();
    }

    /// <summary>
    /// Updates the timer UI inside the game
    /// </summary>
    /// <param name="timer"></param>
    public void TimerUi(int timer)
    {
        textItems[1].text = timer.ToString();
    }
}