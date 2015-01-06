using UnityEngine;
using System.Collections;

public class ResetPositionAtPosition : MonoBehaviour
{

    public Vector3 originalPosition;
    public float resetAfterTranslation;

    // Use this for initialization
    void Start()
    {
        originalPosition = transform.position;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(transform.position.x - originalPosition.x) > resetAfterTranslation)
        {
            transform.position = originalPosition;
        }
    }
}
