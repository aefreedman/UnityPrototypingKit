// SimpleKeyboardMove.cs
// Last edited 10:46 AM 04/17/2015 by Aaron Freedman

using UnityEngine;

namespace Assets.PrototypingKit.Controls
{
    /// <summary>
    ///     Moves the <see cref="Transform"/> using <see cref="Transform.Translate"/>
    ///     <para>Buttons default to Up/Down/Left/Right</para>
    /// </summary>
    public class SimpleKeyboardMove : MonoBehaviour
    {
        [SerializeField] private string upButton;
        [SerializeField] private string downButton;
        [SerializeField] private string leftButton;
        [SerializeField] private string rightButton;
        [SerializeField] private float moveSpeed;

        private void Start()
        {
            if (string.IsNullOrEmpty(upButton)) upButton = "Up";
            if (string.IsNullOrEmpty(downButton)) downButton = "Down";
            if (string.IsNullOrEmpty(leftButton)) leftButton = "Left";
            if (string.IsNullOrEmpty(rightButton)) rightButton = "Right";
        }

        // Update is called once per frame
        private void Update()
        {
            if (Input.GetButton(upButton))
            {
                transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
            }

            if (Input.GetButton(downButton))
            {
                transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
            }

            if (Input.GetButton(rightButton))
            {
                transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            }

            if (Input.GetButton(leftButton))
            {
                transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            }
        }
    }
}