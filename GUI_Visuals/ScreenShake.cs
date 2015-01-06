using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    Vector3 target;
    Vector3 originalPosition;
    Transform camPos;
    public bool shake;
    private float startTime;
    private float activeTime;
    private float intensity;
    
    private void Start()
    {
        originalPosition = Camera.main.gameObject.transform.position;
        camPos = camera.gameObject.transform;
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
        camPos.position = Vector3.Lerp(camPos.position, target, 10 * Time.deltaTime);
    }

    public void Shake()
    {
        target = new Vector3(originalPosition.x + Random.Range(-intensity, intensity), originalPosition.y + Random.Range(-intensity, intensity), originalPosition.z);
    }

    public void StartShake(float time, float _intensity)
    {
        shake = true;
        activeTime = time;
        startTime = Time.time;
        intensity = _intensity;
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