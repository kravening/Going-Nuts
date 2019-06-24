using System.Collections;
using UnityEngine;

/// <summary>
/// This class houses the behaviour needed to spawn a gameobject to shoot off into the game world.
/// </summary>
public class Shooting : MonoBehaviour
{
    public Camera _arCamera;
    [SerializeField]private float _cooldown = 0.8f;
    private bool _canShoot;

    private void Awake()
    {
        if (_arCamera)
        {
            return;
        }

        _arCamera = Camera.main;
    }

    private void Start()
    {
        EventCatalogue.SingleTouchEvent += Shoot;
        StartCoroutine(StartCooldown(_cooldown));
    }

    private void OnDestroy()
    {
        EventCatalogue.SingleTouchEvent -= Shoot;
    }

    /// <summary>
    /// Call this function to shoot a bullet.
    /// </summary>
    private void Shoot()
    {
        if (_canShoot)  
        {
            GameObject bullet = Instantiate(ProjectileManager.instance.GetProjectileFromQueue(), _arCamera.transform.position + (_arCamera.transform.forward * 1), _arCamera.transform.rotation);
            bullet.transform.parent = this.transform;

            DisplayPlayerIngredient.instance.DisplayNextIngredient(ProjectileManager.instance.GetIngredientTypeFromIndex(0));

            StartCoroutine(StartCooldown(_cooldown));
        }
    }

    /// <summary>
    /// This routine manages the cooldown for the bullet
    /// </summary>
    /// <param name="cooldownTime"></param>
    /// <returns></returns>
    private IEnumerator StartCooldown(float cooldownTime)
    {
        _canShoot = false;
        yield return new WaitForSeconds(cooldownTime);
        _canShoot = true;
    }
    
}
