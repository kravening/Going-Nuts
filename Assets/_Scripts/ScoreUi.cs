using TMPro;
using UnityEngine;

public class ScoreUi : Textbase
{
	private void Start()
	{
		EventCatalogue.UpdateScoreEvent += UpdateText;
	}

	private void OnDestroy()
	{
		EventCatalogue.UpdateScoreEvent -= UpdateText;
	}
}