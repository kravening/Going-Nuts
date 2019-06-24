using TMPro;
using UnityEngine;

public class TimerUi : Textbase
{
	private void Start()
	{
		EventCatalogue.UpdateTimer += UpdateText;
	}

	private void OnDestroy()
	{
		EventCatalogue.UpdateTimer -= UpdateText;
	}
}
