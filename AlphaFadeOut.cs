// AlphaFadeOut.cs
// Last edited 7:43 PM 04/15/2015 by Aaron Freedman

using UnityEngine;

namespace Assets.PrototypingKit
{
    public class AlphaFadeOut : MonoBehaviour
    {
        public enum FadeType
        {
            sprite
        }

        public FadeType type;

        public float speed;

        // Use this for initialization
        private void Start() {}

        // Update is called once per frame
        private void Update()
        {
            switch (type)
            {
                case FadeType.sprite:
                    var sprite = GetComponent<SpriteRenderer>();
                    sprite.color = Color.Lerp(sprite.color, Color.clear, Time.deltaTime * speed);
                    break;
            }
        }
    }
}