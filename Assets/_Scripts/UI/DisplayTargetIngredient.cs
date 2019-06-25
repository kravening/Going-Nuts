using UnityEngine;

/// <summary>
/// This class displays the next ingredient that a target wants
/// </summary>
public class DisplayTargetIngredient : MonoBehaviour
{
    /// <summary>
    /// the renderer of the ingredient display.
    /// </summary>
    public SpriteRenderer _ingredientSprite;

    /// <summary>
    /// references the target controller that pairs with this class
    /// </summary>
    private TargetController _targetController;

    private void Awake()
    {
        _targetController = GetComponent<TargetController>();
    }

    private void Start()
    {
        DisplayIngredient();
    }

    /// <summary>
    /// Call this function to display the ingredient
    /// </summary>
    public void DisplayIngredient()//TODO: kan deze functie private zijn?
    {
        Sprite food = SpriteDataManager.instance.GetFoodSpriteFromList(IngredientTypeRegister.instance.GetIngredientIndex(_targetController._preferredFoodType));
        _ingredientSprite.sprite = food;
    }

}
