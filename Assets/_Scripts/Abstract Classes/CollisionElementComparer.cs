using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CollisionElementComparer : ElementComparerBase
{
    /// <summary>
    /// make a comparison of the elements on the colliding object.
    /// </summary>
    /// <param name="collider"></param>
    protected virtual void OnCollisionEnter(Collision collider)
    {
        CheckElementLegality(collider.gameObject.GetComponent<ScriptableObjectElement>());
    }
}
