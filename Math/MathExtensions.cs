using UnityEngine;
using System.Collections;

public class MathExtensions : MonoBehaviour
{
    public static float AngleRad(Vector2 a, Vector2 b)
    {
        return Mathf.Atan2(a.x * b.y - a.y * b.x, a.x * b.y + a.y * b.x);
    }

    public static float Angle(Vector2 a, Vector2 b)
    {
        return Mathf.Atan2(a.x * b.y - a.y * b.x, a.x * b.y + a.y * b.x) * Mathf.Rad2Deg;
    }
}
