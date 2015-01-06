using UnityEngine;
using System.Collections;

public abstract class Singleton<T> : MonoBehaviour where T : UnityEngine.Object
{
    protected static T instance;
    
    /// <summary>
    /// Gets or sets the instance.
    /// </summary>
    /// <value>The instance.</value>
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                Instance = FindObjectOfType<T>();
            }
            return instance;
        }
        set
        {
            instance = value;
        }
    }
}
