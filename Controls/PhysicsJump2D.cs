// PhysicsJump2D.cs
// Last edited 7:43 PM 04/15/2015 by Aaron Freedman

using UnityEngine;

namespace Assets.PrototypingKit.Controls
{
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

        // Use this for initialization
        private void Start()
        {
            extendedJumpTime = 0;
            forceInit = force;
        }

        // Update is called once per frame
        private void Update() {}

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.name.Contains("Building"))
            {
                canJump = true;
            }
        }

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