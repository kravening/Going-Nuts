using UnityEngine;

/// <summary>
/// This class displays the next ingredient that a target wants
/// </summary>
public class DisplayTargetIngredient : MonoBehaviour
{
    public SpriteRenderer _ingredientSprite; // sprite for the ingredient
    private TargetController _targetController; // reference to target controller

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
        Sprite food = SpriteDataManager.instance.GetFoodSpriteFromList((int) _targetController.GetPreferredFoodType());
        _ingredientSprite.sprite = food;
    }
    
}
