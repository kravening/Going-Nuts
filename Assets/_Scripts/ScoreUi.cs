using TMPro;
using UnityEngine;

public class ScoreUi : MonoBehaviour
{
	[SerializeField]private TextMeshProUGUI textItem;

	private void Start()
	{
		Highscore.UpdateScoreEvent += UpdateScoreUi;
	}

	private void OnDestroy()
	{
		Highscore.UpdateScoreEvent -= UpdateScoreUi;
	}

	private void UpdateScoreUi(int score)
	{
		textItem.text = score.ToString();
	} 
}