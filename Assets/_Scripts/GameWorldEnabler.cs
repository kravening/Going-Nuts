using UnityEngine;

public class GameWorldEnabler : DefaultTrackableEventHandler
{
    public GameObject gameWorld;

    protected override void OnTrackingFound()
    {
        base.OnTrackingFound();
        Time.timeScale = 1;
    }

    protected override void OnTrackingLost()
    {
        base.OnTrackingLost();
        transform.position = new Vector3(-9999, -9999, -9999);
        Time.timeScale = 0;
    }
}
