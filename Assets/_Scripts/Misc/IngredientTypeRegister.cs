using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


/// <summary>
/// a class that holds a selection of scriptable objects
/// </summary>
public class IngredientTypeRegister : SingletonBase<IngredientTypeRegister>
{

    /// <summary>
    /// holds a list of ingredients
    /// </summary>
    [SerializeField] private List<ScriptableObject> _ingredients;

    /// <summary>
    /// references the list that holds a list of ingredients
    /// </summary>
    public List<ScriptableObject> ingredients
    {
        get { return _ingredients; }
    }

    /// <summary>
    /// returns an ingredient index based on the ingredient given
    /// </summary>
    /// <param name="incomingIngredient"></param>
    /// <returns></returns>
    public int GetIngredientIndex(ScriptableObject incomingIngredient)
    {
        for (int i = 0; i < ingredients.Count - 1; i++)
        {
            if (incomingIngredient == ingredients[i])
            {
                return i;
            }
        }

        //fallback value
        return 0;
    }

    /// <summary>
    /// returns a random element from the ingredient type register.
    /// </summary>
    /// <returns></returns>
    public ScriptableObject GetRandomIngredient()
    {
        return _ingredients[Random.Range(0, _ingredients.Count)];
    }
}
