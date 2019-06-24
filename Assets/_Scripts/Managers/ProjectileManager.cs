using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class takes track of which projectile is next in the queue to shoot.
/// </summary>
public class ProjectileManager : SingletonBase<ProjectileManager>
{
    public Projectile projectile;// all the projectile objects available
    public List<ScriptableObject> ingredientQueue =  new List<ScriptableObject>(); // queue for next projectile

    private int _queueSize = 4;

    protected override void Awake()
    {
        base.Awake();
        InitializeProjectileQueue();
    }

    /// <summary>
    /// this function takes care of the initial setup of the queue.
    /// </summary>
    private void InitializeProjectileQueue()
    {
        for (int i = 0; i < _queueSize; i++)
        {
            QueueNewFoodType();
        }
    }
    
    /// <summary>
    /// this function adds a new projectile to the queue, picked randomly from the possible types of projectile.
    /// </summary>
    private void QueueNewFoodType()
    {
        ingredientQueue.Add(IngredientTypeRegister.instance.GetRandomIngredient());
    }

    /// <summary>
    /// this function returns the first game object in the queue and then generates a new one.
    /// </summary>
    /// <returns></returns>
    public GameObject GetProjectileFromQueue()
    {
        projectile.ingredientType.element = ingredientQueue[0];
        GameObject projectileToShoot = projectile.gameObject;

        ingredientQueue.RemoveAt(0);
        QueueNewFoodType();
        return projectileToShoot;
    }

    public ScriptableObject GetIngredientTypeFromIndex(int index)
    {
        return ingredientQueue[index];
    }
    
    public Projectile GetProjectileWithSetIngredientType(ScriptableObject ingredientType)
    {
        ingredientQueue.Add(ingredientType);
        projectile.ingredientType.element = ingredientQueue[ingredientQueue.Count - 1];
        Projectile newProjectile = projectile;
        ingredientQueue.RemoveAt(ingredientQueue.Count - 1);

        return newProjectile;
    }
}
