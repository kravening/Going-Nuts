/// <summary>
/// References the scoreUI when the score gets updated.
/// </summary>
public class ScoreUi : Textbase
{
    /// <summary>
    /// Subscribes Updatetext to UpdateScoreEvent.
    /// </summary>
    private void Start()
    {
        EventCatalogue.UpdateScoreEvent += UpdateText;
    }
    /// <summary>
    /// Unsubscribes Updatetext from UpdateScoreEvent.
    /// </summary>
    private void OnDestroy()
    {
        EventCatalogue.UpdateScoreEvent -= UpdateText;
    }
}