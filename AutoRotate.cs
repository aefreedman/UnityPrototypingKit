// AutoRotate.cs
// Last edited 1:27 PM 05/16/2015 by Aaron Freedman

using UnityEngine;

public class AutoRotate : MonoBehaviour
{
    public Vector3 rotationSpeed;
    public bool randomize;
    public float min, max;
    public bool world;

    private void Start()
    {
        if (randomize)
        {
            rotationSpeed = new Vector3(Random.Range(min, max), Random.Range(min, max), Random.Range(min, max));
        }
    }

    private void Update()
    {
        if (world)
        {
            transform.Rotate(rotationSpeed * Time.deltaTime, Space.World);
        }
        else
        {
            transform.Rotate(rotationSpeed * Time.deltaTime);
    
        }
    }
}