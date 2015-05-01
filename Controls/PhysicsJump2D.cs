// PhysicsJump2D.cs
// Last edited 10:33 AM 04/17/2015 by Aaron Freedman

using UnityEngine;

namespace Assets.PrototypingKit.Controls
{
    /// <summary>
    ///     A simple script that uses <see cref="Rigidbody2D"/> to add forces to the attached rigidbody in a jimp-like manner.
    ///     <para>Not very good right now.</para>
    /// </summary>
    [RequireComponent(typeof (Rigidbody2D))]
    public class PhysicsJump2D : MonoBehaviour
    {
        public bool extendedJump; // additional jump force if button is held down
        public float force;
        public float forceInit;
        public float extendedJumpForce;
        public float extendedJumpTimeMax;
        public float extendedJumpTime;
        public bool canJump;

        private void Start()
        {
            extendedJumpTime = 0;
            forceInit = force;
        }

        private void Update() {}

        public void DoJump(float overrideForce = 0)
        {
            float _force = (overrideForce != 0) ? overrideForce : force;
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * _force);
            extendedJumpTime = extendedJumpTimeMax;
            canJump = false;
        }

        public void DoExtendJump()
        {
            extendedJumpTime -= Time.deltaTime;
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * extendedJumpForce * (Time.deltaTime / extendedJumpTimeMax));
        }

        public void Reset()
        {
            extendedJumpTime = 0;
        }
    }
}