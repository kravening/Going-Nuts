using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This class displays the next ingredient that the player wil be able to shoot
/// </summary>
public class DisplayPlayerIngredient : SingletonBase<DisplayPlayerIngredient>
{
    public Image nextPlayerIngredient;

    /// <summary>
    /// Call this function to display the ingredient
    /// </summary>
    public void DisplayNextIngredient(ScriptableObject food)
    {
        nextPlayerIngredient.GetComponent<Image>().sprite = SpriteDataManager.instance.GetFoodSpriteFromList(IngredientTypeRegister.instance.GetIngredientIndex(food));


    }
}
