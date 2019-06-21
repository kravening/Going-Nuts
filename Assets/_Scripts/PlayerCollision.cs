using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This class handles the collision for the player
/// </summary>
public class PlayerCollision : CollisionElementComparer
{
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
