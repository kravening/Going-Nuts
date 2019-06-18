using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class takes track of which projectile is next in the queue to shoot.
/// </summary>
public class ProjectileManager : SingletonBase<ProjectileManager>
{
    public Projectile projectile;// all the projectile objects available
    public List<FoodEnums.FoodType> foodTypeQueue =  new List<FoodEnums.FoodType>(); // queue for next projectile

    private int _queueSize = 4;

    public static ProjectileManager instance;

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
        //add it to the queue
        foodTypeQueue.Add(FoodEnums.GetRandomFood());
    }

    /// <summary>
    /// this function returns the first game object in the queue and then generates a new one.
    /// </summary>
    /// <returns></returns>
    public GameObject GetProjectileFromQueue()
    {
        projectile.foodType = foodTypeQueue[0];
        GameObject projectileToShoot = projectile.gameObject;

        foodTypeQueue.RemoveAt(0);
        QueueNewFoodType();
        return projectileToShoot;
    }

    public FoodEnums.FoodType GetFoodEnumFromIndex(int index)
    {
        return foodTypeQueue[index];
    }
    
    public Projectile GetProjectileWithSetIngredientType(FoodEnums.FoodType ingredientType)
    {
        foodTypeQueue.Add(ingredientType);
        projectile.foodType = foodTypeQueue[foodTypeQueue.Count - 1];
        Projectile newProjectile = projectile;
        foodTypeQueue.RemoveAt(foodTypeQueue.Count - 1);

        return newProjectile;
    }
}
