using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    private float activeTime;
    private Transform camPos;
    private float intensity;
    private Vector3 originalPosition;
    public bool shake;
    public bool useLerp;
    private float startTime;
    private Vector3 target;

    private void Start()
    {
        originalPosition = Camera.main.gameObject.transform.position;
        camPos = GetComponent<Camera>().gameObject.transform;
        target = originalPosition;
        shake = false;
    }

    private void Update()
    {
        if (shake)
        {
            if (Time.time > startTime + activeTime)
            {
                StopShake();
            }
            else
            {
                Shake();
            }
        }

        if (useLerp)
        {
            camPos.position = Vector3.Lerp(camPos.position, target, 10 * Time.deltaTime);
        }
        else
        {
            camPos.position = target;
        }

    }

    public void Shake()
    {
        target = new Vector3(originalPosition.x + Random.Range(-intensity, intensity),
            originalPosition.y + Random.Range(-intensity, intensity), originalPosition.z);
    }

    public void StartShake(float time, float intensity)
    {
        shake = true;
        activeTime = time;
        startTime = Time.time;
        this.intensity = intensity;
    }

    public void StopShake()
    {
        ResetPosition();
    }

    public void ResetPosition()
    {
        target = originalPosition;
    }
}