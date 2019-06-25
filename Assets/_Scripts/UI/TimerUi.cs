/// <summary>
/// handles the subscription of the the UI element to that of the update timer event.
/// </summary>
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
