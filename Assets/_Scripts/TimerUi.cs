using TMPro;
using UnityEngine;

public class TimerUi : Textbase
{
	/// <summary>
	/// Subscribes Update text die in Text base staat op Het UpdatescoreEvent
	/// </summary>
	private void Start()
	{
		EventCatalogue.UpdateTimer += UpdateText;
	}

	/// <summary>
	/// Subscribes Update text die in Text base staat op Het UpdatescoreEvent
	/// </summary>
	private void OnDestroy()
	{
		EventCatalogue.UpdateTimer -= UpdateText;
	}
}
