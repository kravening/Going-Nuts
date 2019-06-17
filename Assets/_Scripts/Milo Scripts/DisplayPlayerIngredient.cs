using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This class displays the next ingredient that the player wil be able to shoot
/// </summary>
public class DisplayPlayerIngredient : MonoBehaviour
{
    public Image nextPlayerIngredient;

    public static DisplayPlayerIngredient instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    private void OnDestroy()
    {
        if (instance == this)
        {
            instance = null;
        }
    }

    /// <summary>
    /// Call this function to display the ingredient
    /// </summary>
    public void DisplayNextIngredient(FoodEnums.FoodType food)
    {
        nextPlayerIngredient.GetComponent<Image>().sprite = SpriteDataManager.instance.GetFoodSpriteFromList((int)food);
    }
}
