/// <summary>
/// This class handles the collision for the player
/// </summary>
public class PlayerCollision : CollisionElementComparer
{
    /// <summary>
    /// gets called when the correct element collides with this object. this function takes care of the adding the score and removing the colliding object.
    /// </summary>
    protected override void OnLegalElementFound()
    {
        Highscore.instance.DecrementScore(100);
        Destroy(_lastElement.gameObject);
    }

    /// <summary>
    /// gets called when the wrong element collides with this object.
    /// </summary>
    protected override void OnIllegalElementFound()
    {
        //do nothing
    }
}
