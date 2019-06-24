using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This class handles returns the sprites for the different foods 
/// </summary>
public class SpriteDataManager : SingletonBase<SpriteDataManager>
{

    /// <summary>
    /// holds the sprites of the different ingredients, the sprites must be ordered in the same order as the foodList enum.
    /// </summary>
    public List<Sprite> foodSpriteList = new List<Sprite>();


    /// <summary>
    /// returns a sprite based on an index given.
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public Sprite GetFoodSpriteFromList(int index)
    {
        if (index > foodSpriteList?.Count)
        {
            return foodSpriteList[0];
        }

        return foodSpriteList[index];
    }


}
