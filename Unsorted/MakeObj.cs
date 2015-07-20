// MakeObj.cs
// Last edited 11:07 AM 07/08/2015 by Aaron Freedman

using System;
using System.Collections.Generic;
using Assets.ObjectPool.Scripts;
using UnityEngine;
using Random = UnityEngine.Random;

public class MakeObj : MonoBehaviour
{
    public GameObject prefab;
    public int numberToSpawn;
    public int spawned;
    public float zPos;
    public bool spawnOnScreen;
    public bool threeD;
    [Range(0.01f, 0.99f)] public float border;
    public int unitRadius;
    public int batchSize;
    public float delayTime;
    private float timer;
    public Transform parentTransform;
    public Vector3 translation;
    private List<GameObject> _objs;
    //public GameManagerBase<T> gm;

    private void Start()
    {
        ObjectPool.CreatePool(prefab, numberToSpawn * 2);
        _objs = new List<GameObject>();
        timer = 0f;
    }

    private void Update()
    {
        _objs.Clear();
        if (spawned < numberToSpawn && timer <= 0)
        {
            _objs = Spawn();
        }
        else if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
    }

    private List<GameObject> Spawn()
    {
        List<GameObject> list = new List<GameObject>();
        if (spawnOnScreen)
        {
            for (var i = 0; i < batchSize; i++)
            {
                //list.Add(parentTransform
                //    ? ObjectPool.Spawn(prefab, parentTransform, translation + GameManager.RandomScreenPosition(border, zPos))
                //    : ObjectPool.Spawn(prefab, GameManager.RandomScreenPosition(border, zPos)));
                //spawned++;
            }
        }
        else
        {
            for (var i = 0; i < batchSize; i++) // TODO: (Fix) will spawn in a square not a circle
            {
                list.Add(threeD
                    ? parentTransform
                        ? ObjectPool.Spawn(prefab, parentTransform,
                                           translation +
                                           new Vector3(Random.Range(-unitRadius, unitRadius), zPos, Random.Range(-unitRadius, unitRadius)))
                        : ObjectPool.Spawn(prefab,
                                           new Vector3(Random.Range(-unitRadius, unitRadius), zPos, Random.Range(-unitRadius, unitRadius)))
                    :parentTransform
                        ? ObjectPool.Spawn(prefab, parentTransform,
                                           translation +
                                           new Vector3(Random.Range(-unitRadius, unitRadius), Random.Range(-unitRadius, unitRadius), zPos))
                        : ObjectPool.Spawn(prefab,
                                           new Vector3(Random.Range(-unitRadius, unitRadius), Random.Range(-unitRadius, unitRadius), zPos)));

                spawned++;
            }
        }

        timer = delayTime;
        return list;
    }

    public void Reset() {}

    public void AddBatch(string methodName = "") 
    {
        numberToSpawn += batchSize;
        _objs = Spawn();
        timer = delayTime;
        foreach (GameObject o in _objs)
        {
            o.SendMessage(methodName);
        }
    }
}