using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This class handles the collision for the player
/// </summary>
public class PlayerCollision : CollisionElementComparer
{
    /// <summary>
    /// Takes care of the adding the score and removes the target that you hit
    /// </summary>
    protected override void OnLegalElementFound()
    {
        Highscore.instance.DecrementScore(100);
        Destroy(_lastElement.gameObject);
    }

    protected override void OnIllegalElementFound()
    {
        //nothing
    }
}
