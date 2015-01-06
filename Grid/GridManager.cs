using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// GridManager centralizes control of Grid objects but is not responsible for how a Grid object is created.
/// 
/// The GridManager is especially helpful when using multiple Grid objects. 
/// 
/// (A lot of this isn't implemented in this Unity version.)
/// </summary>
public abstract class GridManager<T> : Singleton<T> where T : UnityEngine.Object
{

    [HideInInspector]
    public List<Grid> grid;

    protected virtual void Start()
    {
        Grid[] grids = FindObjectsOfType<Grid>();
        foreach (Grid g in grids)
        {
            grid.Add(g);
        }
    }

//    protected virtual void Update()
//    {
//
//    }

}