﻿using TMPro;
using UnityEngine;

public class ScoreUi : Textbase
{
	/// <summary>
	/// Subscribes Update text die in Text base staat op Het UpdatescoreEvent
	/// </summary>
	private void Start()
	{
		EventCatalogue.UpdateScoreEvent += UpdateText;
	}
	/// <summary>
	/// Unsubcribes Update text on UpdateScoreEvent
	/// </summary>
	private void OnDestroy()
	{
		EventCatalogue.UpdateScoreEvent -= UpdateText;
	}
}