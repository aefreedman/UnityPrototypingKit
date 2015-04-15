using UnityEngine;
using System;

/// <summary>
/// Contains all gamestate information.
/// Used as a singleton and always accessible via static <c>Instance</c>.
/// </summary>
public abstract class GameManagerBase<T> : Singleton<T> where T : UnityEngine.Object
{
    public delegate void GameState();

    public GameState gameState;

    public bool startDebug;
    public bool useMouseCursor;
    public bool canReset;
    public string ResetGameInputName;

    protected virtual void Awake()
    {
    }

    protected virtual void Start()
    {
        if (useMouseCursor)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        gameState = DefaultGameState;
    }

    protected virtual void Update()
    {
        if (canReset && Input.GetButtonDown(ResetGameInputName))
        {
            ReloadScene();
        }
        gameState();
    }

    protected virtual void FixedUpdate()
    {
    }

    protected virtual void DefaultGameState()
    {
    }

    public virtual void ChangeGameState(GameState state)
    {
        gameState = state;
    }

    /// <summary>
    /// Reloads the scene currently in use.
    /// </summary>
    public virtual void ReloadScene()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    /// <summary>
    /// Spawns the GameObject at Origin.
    /// </summary>
    /// <returns>The GameObject</returns>
    /// <param name="objectToSpawn">Object to spawn.</param>
    public GameObject SpawnGameObject(GameObject objectToSpawn)
    {
        GameObject o = GameObject.Instantiate(objectToSpawn) as GameObject;
        return o;
    }

    /// <summary>
    /// Spawns the GameObject.
    /// </summary>
    /// <returns>The GameObject spawned.</returns>
    /// <param name="objectToSpawn">Object to spawn.</param>
    /// <param name="pos">Desired position of GameObject.</param>
    public GameObject SpawnGameObject(GameObject objectToSpawn, Vector3 pos)
    {
        GameObject o = GameObject.Instantiate(objectToSpawn, pos, Quaternion.identity) as GameObject;
        return o;
    }

    /// <summary>
    /// Takes a screenshot.
    /// </summary>
    /// <param name="res">Sample-size multiplier (e.g. 1x, 2x, etc.)</param>
    public static void TakeScreenshot(int res)
    {
        string path = Application.persistentDataPath + "/" + System.DateTime.Now.Year.ToString() +
                      System.DateTime.Now.Month.ToString() + System.DateTime.Now.Day.ToString() + "_" +
                      System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Minute.ToString() +
                      System.DateTime.Now.Second.ToString() +
                      System.DateTime.Now.Millisecond.ToString() +
                      "_scr.png";

        Application.CaptureScreenshot(path, res);
        path = Application.persistentDataPath + "/" + path;
        Debug.Log(path);
    }
}