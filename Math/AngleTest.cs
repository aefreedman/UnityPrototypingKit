using UnityEngine;
using System.Collections;

public class AngleTest : MonoBehaviour
{
    public Vector2 vectorOne, vectorTwo;
    public float angleUnity, angleExtension, angleExRad;
    public float dot;

    public void Update()
    {
        angleUnity = Vector2.Angle(vectorOne, vectorTwo);
//        angleExtension = MathExtensions.Angle(vectorTwo, vectorOne);
//        angleExRad = MathExtensions.AngleRad(vectorTwo, vectorOne);
        dot = Vector2.Dot(vectorOne, vectorTwo);
        angleExRad = Mathf.Acos(Vector2.Dot(vectorOne, vectorTwo) / vectorOne.magnitude * vectorTwo.magnitude);
    }
    
}
