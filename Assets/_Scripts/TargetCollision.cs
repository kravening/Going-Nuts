/// <summary>
/// This class handles the incoming collisions of the targets
/// </summary>
public class TargetCollision : CollisionElementComparer
{
    /// <summary>
    /// references the target controller on the game object this class is on
    /// </summary>
    private TargetController _targetController;

    private void Awake()
    {
        _targetController = gameObject.GetComponent<TargetController>();
    }

    /// <summary>
    /// comparison succeeded, in this case an object with the right element is colliding
    /// </summary>
    protected override void OnLegalElementFound()
    {
        EatIngredient();
        Destroy(_lastElement.gameObject);
    }

    /// <summary>
    /// comparison succeeded, but in this case an object with the wrong element is colliding
    /// </summary>
    protected override void OnIllegalElementFound()
    {
        Projectile collidingProjectile = _lastElement?.gameObject?.GetComponent<Projectile>();
        if (collidingProjectile)
        {
            ThrowIngredient(collidingProjectile);
        }
    }

    /// <summary>
    /// if the colliding object is a nut this function gets called and calls for the target to hide, and increments the score.
    /// </summary>
    private void EatIngredient()
    {
        _targetController?.EatIngredient();
    }

    /// <summary>
    /// when the colliding element is of the wrong type, throw it.
    /// </summary>
    /// <param name="ingredient"></param>

    private void ThrowIngredient(Projectile ingredient)
    {
        _targetController?.ThrowIngredient(ingredient);
    }
}
