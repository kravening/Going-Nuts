using UnityEngine;

/// <summary>
/// this class queues ingredients and gives the projectile a corresponding ingredient based on the first order in the ingredient queue.
/// </summary>
public class IngredientManager : SingletonBase<IngredientManager>
{
    /// <summary>
    /// reference to the projectile prefab
    /// </summary>
    public Projectile projectile;

    /// <summary>
    /// e queue of ingredients
    /// </summary>
    public GenericQueue<ScriptableObject> ingredientQueue = new GenericQueue<ScriptableObject>();

    /// <summary>
    /// the maximum size of the queue
    /// </summary>
    private int _queueSize = 4;

    private void Start()
    {
        InitializeProjectileQueue();
    }

    protected override void Awake()
    {
        base.Awake();
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
        ingredientQueue.QueueNewGeneric(IngredientTypeRegister.instance.GetRandomIngredient());
    }

    /// <summary>
    /// this function returns the first game object in the queue and then generates a new one.
    /// </summary>
    /// <returns></returns>
    public GameObject GetProjectileFromQueue()
    {
        projectile.ingredientType.element = ingredientQueue.GetGenericFromQueue(0);
        GameObject projectileToShoot = projectile.gameObject;

        ingredientQueue.RemoveFromQueue(0);
        QueueNewFoodType();
        return projectileToShoot;
    }

    public ScriptableObject GetIngredientTypeFromIndex(int index)
    {
        return ingredientQueue.GetGenericFromQueue(index);
    }

    public Projectile GetProjectileWithSetIngredientType(ScriptableObject ingredientType)
    {
        ingredientQueue.QueueNewGeneric(ingredientType);
        projectile.ingredientType.element = ingredientQueue.queue[ingredientQueue.queue.Count - 1];
        Projectile newProjectile = projectile;
        ingredientQueue.RemoveFromQueue(ingredientQueue.queue.Count - 1);

        return newProjectile;
    }
}
