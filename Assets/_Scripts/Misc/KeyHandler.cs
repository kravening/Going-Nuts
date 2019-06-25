using System;
using UnityEngine;

/// <summary>
/// Saves and stores data with playerprefs.
/// </summary>
public class KeyHandler
{
    /// <summary>
    /// Sets the value of the given keyName depending on what type it is (string, int or float) and saves it to PlayerPrefs
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="keyName"></param>
    /// <param name="data"></param>
    public void SetKey<T>(string keyName, T data)
    {
        switch (Type.GetTypeCode(typeof(T)))
        {
            case TypeCode.String:
                PlayerPrefs.SetString(keyName, (string)(object)data);
                break;
            case TypeCode.Int32:
                PlayerPrefs.SetInt(keyName, (int)(object)data);
                break;
            default:
                PlayerPrefs.SetFloat(keyName, (float)(object)data);
                break;
        }
        SaveKey();
    }

    /// <summary>
    /// Gets the value of the given keyName depending on what type it is (string, int or float)
    /// </summary>
    /// <param name="keyName"></param>
    /// <returns></returns>
    public dynamic GetKey(string keyName)
    {
        if (PlayerPrefs.GetString(keyName) != "")
        {
            return PlayerPrefs.GetString(keyName);
        }
        else if (PlayerPrefs.GetInt(keyName) != 0)
        {
            return PlayerPrefs.GetInt(keyName);
        }
        else if (Math.Abs(PlayerPrefs.GetFloat(keyName)) > 0)
        {
            return PlayerPrefs.GetFloat(keyName);
        }
        else
        {
            return null;
        }
    }

    /// <summary>
    /// Saves the key in PlayerPrefs
    /// </summary>
    private void SaveKey()
    {
        PlayerPrefs.Save();
    }
}
