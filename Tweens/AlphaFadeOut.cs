using UnityEngine;
using System.Collections;

public class AlphaFadeOut : MonoBehaviour
{

    public enum FadeType
    {
        sprite
    }
    public FadeType type;

    public float speed;

    // Use this for initialization
    void Start()
    {
    
    }
    
    // Update is called once per frame
    void Update()
    {
        switch (type)
        {
            case FadeType.sprite:
                SpriteRenderer sprite = GetComponent<SpriteRenderer>();
                sprite.color = Color.Lerp(sprite.color, Color.clear, Time.deltaTime * speed);
                break;
        }
    }
}
