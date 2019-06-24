using TMPro;
using UnityEngine;

public class TimerUi : Textbase
{
	private void Start()
	{
		GameTimeManager.UpdateTimer += UpdateText;
	}

	private void OnDestroy()
	{
		GameTimeManager.UpdateTimer -= UpdateText;
	}
}
