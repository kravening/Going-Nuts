using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class handles the incoming collisions of the targets
/// </summary>
public class TargetCollision : CollisionElementComparer
{

    private TargetController _targetController;

    private void Awake()
    {
        _targetController = gameObject.GetComponent<TargetController>();
    }

    protected override void OnLegalElementFound()
    {
        Debug.Log("legal collision");
        EatIngredient();
        Destroy(_lastElement.gameObject);
    }

    protected override void OnIllegalElementFound()
    {
        Debug.Log("illegal collision");
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

    private void ThrowIngredient(Projectile ingredient)
    {
        _targetController?.ThrowIngredient(ingredient);
    }
}
