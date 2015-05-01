// Singleton.cs
// Last edited 7:43 PM 04/15/2015 by Aaron Freedman

#region Usings

using UnityEngine;

#endregion

namespace Assets.PrototypingKit.Patterns
{
    public abstract class Singleton<T> : MonoBehaviour where T : Object
    {
        protected static T instance;

        /// <summary>
        ///     Gets or sets the instance.
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
            private set { instance = value; }
        }
    }
}