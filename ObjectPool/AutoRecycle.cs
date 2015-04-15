using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AutoRecycle : MonoBehaviour
{

    public float time;
    private float init;

	// Use this for initialization
	void Start ()
	{
	    init = time;
        Reset();
	}

    public void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
        }
        else
        {
            Reset();
            ObjectPool.Recycle(gameObject);
        }
    }

    private void Reset()
    {
        time = init;
    }

}
