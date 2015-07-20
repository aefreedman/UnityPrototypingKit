// GameManagerBase.cs
// Last edited 9:43 AM 06/03/2015 by Aaron Freedman

using System;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace Assets.PrototypingKit.Patterns
{
    /// <summary>
    ///     Contains all gamestate information.
    ///     Used as a singleton and always accessible via static <c>Instance</c>.
    /// </summary>
    public abstract class GameManagerBase<T> : Singleton<T> where T : Object
    {
        public delegate void GameState();

        public GameState gameState;

        public bool startDebug;
        public bool useMouseCursor;
        public bool canReset;
        public string ResetGameInputName;

        protected virtual void Awake() {}

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

        protected virtual void FixedUpdate() {}

        protected virtual void DefaultGameState() {}

        public virtual void ChangeGameState(GameState state)
        {
            gameState = state;
        }

        /// <summary>
        ///     Reloads the scene currently in use.
        /// </summary>
        public virtual void ReloadScene()
        {
            Application.LoadLevel(Application.loadedLevel);
        }

        /// <summary>
        ///     Spawns the GameObject at Origin.
        /// </summary>
        /// <returns>The GameObject</returns>
        /// <param name="objectToSpawn">Object to spawn.</param>
        public GameObject SpawnGameObject(GameObject objectToSpawn)
        {
            GameObject o = Instantiate(objectToSpawn);
            return o;
        }

        /// <summary>
        ///     Spawns the GameObject.
        /// </summary>
        /// <returns>The GameObject spawned.</returns>
        /// <param name="objectToSpawn">Object to spawn.</param>
        /// <param name="pos">Desired position of GameObject.</param>
        public GameObject SpawnGameObject(GameObject objectToSpawn, Vector3 pos)
        {
            var o = Instantiate(objectToSpawn, pos, Quaternion.identity) as GameObject;
            return o;
        }

        /// <summary>
        ///     Takes a screenshot.
        /// </summary>
        /// <param name="res">Sample-size multiplier (e.g. 1x, 2x, etc.)</param>
        public static void TakeScreenshot(int res)
        {
            string path = Application.persistentDataPath + "/" + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + "_" +
                          DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond + "_scr.png";

            Application.CaptureScreenshot(path, res);
            path = Application.persistentDataPath + "/" + path;
            Debug.Log(path);
        }

        public static Vector3 RandomScreenPosition(float borderPercent, float zPos = 1f)
        {
            Vector3 v =
                Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(borderPercent * Screen.width, Screen.width * (1f - borderPercent)),
                                                           Random.Range(borderPercent * Screen.height, Screen.height * (1f - borderPercent)),
                                                           zPos));
            return v;
        }

        public static Vector3 RandomScreenPositionThreeD(float borderPercent, float yPos)
        {
            Vector3 v =
                Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(borderPercent * Screen.width, Screen.width * (1f - borderPercent)),
                                                           yPos,
                                                           Random.Range(borderPercent * Screen.height, Screen.height * (1f - borderPercent))));
            return v;
        }

        public static bool RaycastFromMainCameraUsingSecondaryCamera(Camera currentlyVisibleCamera, Vector3 _screenPos, out RaycastHit _hit,
                                                                     float _maxDist)
        {
            Vector3 viewportPos = currentlyVisibleCamera.ScreenToViewportPoint(_screenPos);
            // Screen point from currently visible camera transformed to viewport of actual camera

            //if (GameManager.Instance.startDebug)
            //{
            //    Vector3 worldpoint = currentlyVisibleCamera.ScreenToWorldPoint(viewportPos);
            //    Debug.Log("Touchpos: " + Input.GetTouch(0).position + "\n" + "view: " + viewportPos + "\n" + "world: " + worldpoint);
            //}

            Vector3 mainCamWorldPos = Camera.main.ViewportToWorldPoint(viewportPos);
            mainCamWorldPos.z = 0;

            return Physics.Raycast(Camera.main.transform.position, mainCamWorldPos - Camera.main.transform.position, out _hit, _maxDist);
        }

        public static bool IsObjectOnScreen(Transform objTransform, out Vector2 edge)
        {
            Vector3 vPoint = Camera.main.WorldToViewportPoint(objTransform.position);
            edge = new Vector2(vPoint.x, vPoint.y);
            if (edge.sqrMagnitude > 1 || edge.sqrMagnitude < 0)
            {
                return false;
            }
            return true;
        }


    }
}

public static class GameObjectExtensions
{
    public static void SetActive(this GameObject[] list, bool active)
    {
        foreach (GameObject o in list)
        {
            o.SetActive(active);
        }
    }
}