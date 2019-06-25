using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class controls the behaviour of the target.
/// </summary>
public class TargetController : MonoBehaviour
{
    /// <summary>
    /// this is a reference to the treerufflebehaviour on the inhabitants tree.
    /// </summary>
    [SerializeField] private TreeRuffleBehaviour treeRuffleBehaviour;

    /// <summary>
    /// these booleans are use to keep track of the state of the target
    /// </summary>
    private bool _isTargetHidden = true;
    private bool _isHiding = false;

    /// <summary>
    /// this is a reference to the animator component on this object
    /// </summary>
    private Animator _animator;

    /// <summary>
    /// references the foodType this target would like to eat
    /// </summary>
    public ScriptableObject _preferredFoodType;

    private bool _justAte = false;
    private bool hideStarted = false;

    public void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    /// <summary>
    /// this function calls the target to show up.
    /// </summary>
    public void Show()
    {
        if (_isTargetHidden)
        {
            _isTargetHidden = false;
            TargetManager.instance?.TargetShown();
            StartCoroutine(ShowTargetRoutine());
        }
    }

    /// <summary>
    /// this is a routine for showing the targets, ensuring the logic is in the right order.
    /// </summary>
    /// <returns></returns>
    private IEnumerator ShowTargetRoutine()
    {
        treeRuffleBehaviour?.RuffleTree();
        yield return new WaitForSeconds(0.5f);

        _animator?.SetBool(StaticVariables.IS_SHOWING, true);
        yield return new WaitForSeconds(4);

        //if target isn't already hidden or starting to hide.
        if (_isTargetHidden == false && _isHiding == false)
        {
            Hide();
        }
    }

    /// <summary>
    /// this function calls for the target to hide.
    /// </summary>
    private void Hide()
    {
        TargetManager.instance?.TargetHiding();
        StartCoroutine(HideTargetRoutine());
    }

    /// <summary>
    /// this is a routine for hiding the targets, ensuring the logic is in the right order.
    /// </summary>
    private IEnumerator HideTargetRoutine()
    {
        //stops the possibility of this routine being called while it's already running.
        if (hideStarted == true)
        {
            yield break;
        }

        hideStarted = true;

        //wait till the character is done 'eating'
        while (_justAte == true)
        {
            yield return new WaitForSeconds(0);
        }

        _isHiding = true;
        _animator?.SetBool(StaticVariables.IS_SHOWING, false);
        yield return new WaitForSeconds(0.5f);
        _isTargetHidden = true;
        _isHiding = false;
        hideStarted = false;
    }

    /// <summary>
    /// this coroutine takes in a projectile and 'throws' a new projectile with the same properties in the direction of the player.
    /// </summary>
    /// <param name="incomingIngredient"></param>
    /// <returns></returns>
    private IEnumerator ThrowIngredientRoutine(Projectile incomingIngredient)
    {
        Projectile newProjectile = IngredientManager.instance.GetProjectileWithSetIngredientType(incomingIngredient.ingredientType.element);
        newProjectile.transform.position = incomingIngredient.transform.position;
        newProjectile.transform.LookAt(Camera.main.transform);

        GameObject instantiatedIngredient = Instantiate(newProjectile.gameObject);
        instantiatedIngredient.transform.parent = TargetManager.instance.transform.parent;

        Destroy(incomingIngredient.gameObject);
        _animator?.SetTrigger(StaticVariables.THROW_INGREDIENT);
        yield return new WaitForSeconds(0.25f);
        Hide();
    }

    /// <summary>
    /// this coroutine increments score and starts the 'eat' animtion.
    /// </summary>
    /// <returns></returns>
    private IEnumerator EatIngredientRoutine()
    {
        Highscore.instance?.IncrementScore(100);
        _animator?.SetTrigger(StaticVariables.EAT_INGREDIENT);

        _justAte = true;
        yield return new WaitForSeconds(0.25f);
        _justAte = false;
        Hide();
    }

    /// <summary>
    /// call this function to throw an ingredient at the player
    /// </summary>
    /// <param name="ingredient"></param>
    public void ThrowIngredient(Projectile ingredient)
    {
        StartCoroutine(ThrowIngredientRoutine(ingredient));
    }

    /// <summary>
    /// call this function to eat the preffered ingredient.
    /// </summary>
    public void EatIngredient()
    {
        StartCoroutine(EatIngredientRoutine());
    }
}
