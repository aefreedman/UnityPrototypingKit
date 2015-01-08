using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;

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

    public static Func<double, double> SimpleMovingAverage(int window)
    {
        var s = new Queue<double>(window);
        return (x) =>
        {
            if (s.Count >= window)
                s.Dequeue();
            
            s.Enqueue(x);
            return s.Average();
        };
    }
}
