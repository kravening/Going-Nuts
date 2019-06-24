using TMPro;
using UnityEngine;

public class TimerUi : MonoBehaviour
{  
	[SerializeField] private TextMeshProUGUI textItems;

	private void Start()
	{
		GameTimeManager.UpdateTimer += SetTimerUi;
	}

	private void OnDestroy()
	{
		GameTimeManager.UpdateTimer -= SetTimerUi;
	}

	private void SetTimerUi(int timer)
	{
		textItems.text = timer.ToString();
	}
}
