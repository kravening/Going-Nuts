using System.Collections;
using UnityEngine;

/// <summary>
/// When this class is added to an object it will move straight forward in its set direction over time
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    /// <summary>
    /// speed of the projectile
    /// </summary>
    [SerializeField] private float _velocity = 20f;

    /// <summary>
    /// time till object self destructs
    /// </summary>
    [SerializeField] private float _destroyAfterSeconds = 2.5f;

    /// <summary>
    /// references the rigidbody.
    /// </summary>
    private Rigidbody _rb;

    /// <summary>
    /// references the sprite renderer
    /// </summary>
    private SpriteRenderer _spriteRenderer;

    /// <summary>
    /// references an element, used for comparing against other elements. used as a way to refer to an ingredient type.
    /// </summary>
    public ScriptableObjectElement ingredientType;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rb = GetComponent<Rigidbody>();
        _rb.useGravity = false;
    }

    private void Start()
    {
        //assigns projectile the matching sprite. 
        _spriteRenderer.sprite = SpriteDataManager.instance.GetFoodSpriteFromList(IngredientTypeRegister.instance.GetIngredientIndex(ingredientType.element));

        StartCoroutine(DestroyProjectileTimer(_destroyAfterSeconds));
        MoveProjectile();
    }

    /// <summary>
    /// this function adds force to the rigidbody making the object this class is on move in it's set direction.
    /// </summary>
    private void MoveProjectile()
    {
        _rb?.AddForce(transform.forward * _velocity, ForceMode.Impulse);
    }

    /// <summary>
    /// when this function gets called the projectile will be destroyed.
    /// </summary>
    private void DestroyProjectile()
    {
        Destroy(this.gameObject);
    }

    /// <summary>
    /// this routine keeps track of when the projectile needs to be destroyed, time wise.
    /// </summary>
    /// <param name="timeTillDestruction"></param>
    /// <returns></returns>
    private IEnumerator DestroyProjectileTimer(float timeTillDestruction)
    {
        yield return new WaitForSeconds(timeTillDestruction);
        DestroyProjectile();
    }
}
