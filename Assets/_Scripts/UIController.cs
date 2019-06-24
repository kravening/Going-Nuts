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
	public int scoreText;


	private void OnDestroy()
	{
		GameTimeManager.GameEndedEvent -= ActivateHighScoreUi;
		GameTimeManager.GameStartedEvent -= DeactivateHighScoreUi;
	}

	private void Start()
	{
		GameTimeManager.GameEndedEvent += ActivateHighScoreUi;
		GameTimeManager.GameStartedEvent += DeactivateHighScoreUi;
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

	private void DeactivateHighScoreUi()
	{
		highScoreUi.SetActive(false);
	}

	private void ActivateHighScoreUi()
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