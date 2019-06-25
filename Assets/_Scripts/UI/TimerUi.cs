public class TimerUi : Textbase
{
    /// <summary>
    /// Subscribes to updateTimer
    /// </summary>
    private void Start()
    {
        EventCatalogue.UpdateTimer += UpdateText;
    }

    /// <summary>
    /// Unsubscribes to updateTimer
    /// </summary>
    private void OnDestroy()
    {
        EventCatalogue.UpdateTimer -= UpdateText;
    }
}
