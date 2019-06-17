using UnityEngine;

/// <summary>
/// This class displays the next ingredient that a target wants
/// </summary>
public class DisplaySquirrelIngredient : MonoBehaviour
{
    public SpriteRenderer _ingredientSprite; // sprite for the ingredient
    private SquirrelController _squirrelController; // reference to squirrel controller

    private void Awake()
    {
        _squirrelController = GetComponent<SquirrelController>();
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
        Sprite food = SpriteDataManager.instance.GetFoodSpriteFromList((int) _squirrelController.GetPreferredFoodType());
        _ingredientSprite.sprite = food;
    }
    
}
