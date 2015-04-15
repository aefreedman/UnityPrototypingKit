// AutoRecycle.cs
// Last edited 7:43 PM 04/15/2015 by Aaron Freedman

using UnityEngine;

namespace Assets.PrototypingKit
{
    /// <summary>
    ///     Automatically recycles an object after time. Destroys object if ObjectPool is not available.
    /// </summary>
    public class AutoRecycle : MonoBehaviour
    {
        public float time;
        private float init;

        // Use this for initialization
        private void Start()
        {
            init = time;
            Reset();
        }

        public void Update()
        {
            if (time > 0)
            {
                time -= Time.deltaTime;
            }
            else
            {
                Reset();
                ObjectPool.Scripts.ObjectPool.Recycle(gameObject);
            }
        }

        private void Reset()
        {
            time = init;
        }
    }
}