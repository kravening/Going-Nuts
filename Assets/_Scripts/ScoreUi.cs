using TMPro;
using UnityEngine;

public class ScoreUi : Textbase
{

	private void Start()
	{
		Highscore.UpdateScoreEvent += UpdateText;
	}

	private void OnDestroy()
	{
		Highscore.UpdateScoreEvent -= UpdateText;
	}
}