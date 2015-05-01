// AlphaFadeOut.cs
// Last edited 7:43 PM 04/15/2015 by Aaron Freedman

using UnityEngine;
using UnityEngine.UI;

namespace Assets.PrototypingKit
{
    public class AlphaFadeOut : MonoBehaviour
    {
        public enum FadeType
        {
            sprite,
            text
        }

        public FadeType type;

        public float speed;
        public float startDelay;

        private void Start()
        {
            
        }

        private void Update()
        {
            if (startDelay > 0)
            {
                startDelay -= Time.deltaTime;
                return;
            }
            switch (type)
            {
                case FadeType.sprite:
                    var sprite = GetComponent<SpriteRenderer>();
                    sprite.color = Color.Lerp(sprite.color, Color.clear, Time.deltaTime * speed);
                    break;

                    case FadeType.text:
                    var text = GetComponent<Text>();
                    var c = new Color(text.color.r, text.color.g, text.color.b, 0);
                    text.color = Color.Lerp(text.color, c, Time.deltaTime * speed);
                    break;
            }
        }
    }
}