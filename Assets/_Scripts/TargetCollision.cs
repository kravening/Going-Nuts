using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class handles the incoming collisions of the targets
/// </summary>
public class TargetCollision : MonoBehaviour
{

    private TargetController _targetController;

    private void Awake()
    {
        _targetController = gameObject.GetComponent<TargetController>();
    }

    private void OnCollisionEnter(Collision collider)
    {
        if (collider.gameObject?.GetComponent<Projectile>()?.foodType == _targetController?.GetPreferredFoodType())
        {
            EatIngredient();
            Destroy(collider.gameObject);
        }
        else if(collider?.gameObject?.GetComponent<Projectile>())
        {
            ThrowIngredient(collider.gameObject.GetComponent<Projectile>());
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
