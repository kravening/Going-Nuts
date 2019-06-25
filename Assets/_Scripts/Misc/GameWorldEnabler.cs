using UnityEngine;

/// <summary>
/// 'enables' or 'disables' the game world based on tracking state
/// </summary>
public class GameWorldEnabler : DefaultTrackableEventHandler
{
    /// <summary>
    /// reference to the gameworld that needs to be moved
    /// </summary>
    public GameObject gameWorld;


    /// <summary>
    /// this function gets called when vuforia finds an image to track, on image found resume all time
    /// </summary>
    protected override void OnTrackingFound()
    {
        base.OnTrackingFound();
        Time.timeScale = 1;
    }

    /// <summary>
    /// this function gets called when vuforia loses an tracking image, this function pauses all time and moves referenced object out of view.
    /// </summary>
    protected override void OnTrackingLost()
    {
        base.OnTrackingLost();
        transform.position = new Vector3(-9999, -9999, -9999);
        Time.timeScale = 0;
    }
}
