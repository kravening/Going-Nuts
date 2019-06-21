using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


/// <summary>
/// a class that holds a selection of scriptable objects
/// </summary>
public class IngredientTypeRegister : SingletonBase<IngredientTypeRegister>
{
    [SerializeField] private List<ScriptableObject> _ingredients;

    public List<ScriptableObject> ingredients
    {
        get { return _ingredients; }
    }

    public int GetIngredientIndex(ScriptableObject incomingIngredient)
    {
        for (int i = 0; i < ingredients.Count-1; i++)
        {
            if (incomingIngredient == ingredients[i])
            {
                return i;
            }
        }

        //fallback value
        return 0;
    }

    public ScriptableObject GetRandomIngredient()
    {
        return _ingredients[Random.Range(0, _ingredients.Count)];
    }
}
