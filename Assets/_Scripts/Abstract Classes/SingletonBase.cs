using UnityEngine;

public abstract class SingletonBase<T> : MonoBehaviour where T : Component
{
    /// <summary>
    /// The _instance.
    /// </summary>
    private static T _instance;

    /// <summary>
    /// Gets the _instance.
    /// </summary>
    /// <value>The _instance.</value>
    public static T instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<T>();
            }
            return _instance;
        }
    }

    /// <summary>
    /// Use this for initialization.
    /// </summary>
    protected virtual void Awake()
    {
        if (_instance == null)
        {
            _instance = this as T;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

}